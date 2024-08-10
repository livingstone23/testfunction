using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using SHM.Domain.Dto.Sahc0100;
using System;

namespace SHM.Domain.Helper;



/// <summary>
/// Clase que permite realizar el manejo del B2C para el manejo de  usuarios
/// </summary>
public static class B2C
{

    //Todo
    ///Dene crearse una funcion que identifique cuantas personas se llamen igual y asige un numero a los siguientes
    ///Esto con el fin de que no se repitan los nombres de usuario en el B2C





    /// <summary>
    /// Funcion que permite registrar un nuevo usuario en Azure B2C
    /// </summary>
    /// <returns></returns>
    public static async Task<B2CUserDTO> RegisterNewUser(EntityMasterGeneralGetDTO data, int totalRegister)
    {
        try
        {

           

            ClientSecretCredential clientCredential = new ClientSecretCredential(Environment.GetEnvironmentVariable("B2CTenatId"), Environment.GetEnvironmentVariable("B2CClientId"), Environment.GetEnvironmentVariable("B2CClientSecret"));

            //ClientSecretCredential clientCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

            GraphServiceClient graphClient = new GraphServiceClient(clientCredential);

            var requestBody = new User
            {
                AccountEnabled = true,
                DisplayName = $"{data.FirstName} {data.LastName}",
                MailNickname = $"{data.FirstName}{data.LastName}",
                OtherMails = new List<string> { $"{data.Email}" },
                Mail = $"{data.Email}",
                GivenName = $"{data.FirstName}{data.LastName}",
                UserPrincipalName = $"{data.FirstName}{data.LastName}{totalRegister}@{Environment.GetEnvironmentVariable("B2CDomain")}",

                PasswordProfile = new PasswordProfile
                {
                    ForceChangePasswordNextSignIn = false,
                    Password = $"{data.B2CPassword}",
                },
                Identities = new List<ObjectIdentity>
                {
                    new ObjectIdentity {SignInType = "emailAddress", Issuer = $"{Environment.GetEnvironmentVariable("B2CDomain")}", IssuerAssignedId = $"{data.Email}"},
                },
            };

            Microsoft.Graph.Models.User result = await graphClient.Users.PostAsync(requestBody);
            var userB2c = new B2CUserDTO()
            {
                B2CKey = Guid.Parse(result.Id),
                B2CUser = requestBody.UserPrincipalName
            };

            return userB2c;
        }
        catch (Exception e)
        {
            await ElasticAlert.LogErrorToElastic(e, "RegisterNewUser");
            Console.WriteLine(e);
            throw;
        }

    }





}