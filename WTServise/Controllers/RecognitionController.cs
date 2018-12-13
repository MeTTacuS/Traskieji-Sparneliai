﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PersonManager;
using PersonManager.FaceApi;
using Swashbuckle.Swagger.Annotations;

namespace WTServise.Controllers
{
    public class RecognitionController : ApiController
    {
        
        //byte[] data = System.IO.File.ReadAllBytes(@"D:\Programavimas\C#\Top\base64_decrypt.bin");

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async System.Threading.Tasks.Task<string> GetPersonAsync([FromBody]byte[] data) 
        {

            try
                {

                    var detectResult = await FaceApiUtils.DetectFace(data);
                    if (detectResult != null && detectResult.Count > 0)
                    {
                        var faceId = detectResult[0].FaceId;
                        if (!string.IsNullOrEmpty(faceId))
                        {
                            var identifyResult = await FaceApiUtils.Identify(
                               faceId,
                               AppSettings.GroupId,
                               1);

                            if (identifyResult != null && identifyResult.Count > 0 && identifyResult[0].Candidates.Count > 0)
                            {
                                var personId = identifyResult[0].Candidates[0].PersonId;
                                var confidence = identifyResult[0].Candidates[0].Confidence;

                                var person = await FaceApiUtils.GetPerson(AppSettings.GroupId, personId);
                                return person.PersonId;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else { return null; }
                    }
                else { return null; }
                }
                catch (FaceApiException ex)
                {
                    return null;                   
                }
                catch (Exception ex)
                {
                    return null;                    
                }

            }

        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<string> PostPersonAsync(PersonCreateRequest person)
        {
            if(await FaceApiUtils.GetPersonGroup() == null)
            {
                await FaceApiUtils.CreatePersonGroup();
            }

            string personId = await FaceApiUtils.CreatePersonInGroup(person.Name, person.UserData);
            var persistedFaceId= await FaceApiUtils.AddFace(personId, person.Image);

            try
            {
                var result = await FaceApiUtils.TrainPersonGroup(AppSettings.GroupId);

                if (result)
                {
                    while (true)
                    {
                        var status = await FaceApiUtils.GetPersonGroupTrainingStatus(AppSettings.GroupId);
                        if (status == PersonGroupTrainingStatus.failed)
                        {
                            return null;
                            break;
                        }
                        else if (status == PersonGroupTrainingStatus.succeeded)
                        {
                            return persistedFaceId;
                            break;
                        }

                        System.Threading.Thread.Sleep(1000);
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (FaceApiException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        private async Task DeletePersonAsync(string personId)
        {

                try
                {
                    var result = await FaceApiUtils.DeletePersonInGroup(AppSettings.GroupId, personId);
                }
                catch (FaceApiException ex)
                {

                }
                catch (Exception ex)
                {

                }

        }
    }
    };

      
