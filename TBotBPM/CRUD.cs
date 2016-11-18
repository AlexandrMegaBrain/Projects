using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TBotBPM.BPM;


namespace TBotBPM
{
    public class CRUD
    {
        private static string serverUri = "http://185.47.152.138:1423/0/ServiceModel/EntityDataService.svc/";
        private static string authServiceUtri = "http://185.47.152.138:1423/ServiceModel/AuthService.svc/Login";

        private static readonly XNamespace ds = "http://schemas.microsoft.com/ado/2007/08/dataservices";
        private static readonly XNamespace dsmd = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
        private static readonly XNamespace atom = "http://www.w3.org/2005/Atom";
        public static object GetOdataObjectBySurname(string surname)
        {
            try
            {
                var authRequest = HttpWebRequest.Create(authServiceUtri) as HttpWebRequest;
                authRequest.Method = "POST";
                authRequest.ContentType = "application/json";
                var bpmCookieContainer = new CookieContainer();
                authRequest.CookieContainer = bpmCookieContainer;
                string userName = "Supervisor";
                string userPassword = "Supervisor";
                using (var requesrStream = authRequest.GetRequestStream())
                {
                    using (var writer = new StreamWriter(requesrStream))
                    {
                        writer.Write(@"{
                                ""UserName"":""" + userName + @""",
                                ""UserPassword"":""" + userPassword + @""",
                                ""SolutionName"":""TSBpm"",
                                ""TimeZoneOffset"":-120,
                                ""Language"":""Ru-ru""
                                }");
                    }
                }
                using (var response = (HttpWebResponse) authRequest.GetResponse())
                {
                    var dataRequest =
                        HttpWebRequest.Create(serverUri + "ContactCollection?$filter= Surname eq '" + surname + "'")
                            as HttpWebRequest;
                    dataRequest.Method = "GET";
                    dataRequest.CookieContainer = bpmCookieContainer;
                    using (var dataResponse = (HttpWebResponse) dataRequest.GetResponse())
                    {

                        XDocument xmlDoc = XDocument.Load(dataResponse.GetResponseStream());
                        var contacts = from entry in xmlDoc.Descendants(atom + "entry")
                            select new
                            {
                                Id = new Guid(entry.Element(atom + "content")
                                    .Element(dsmd + "properties")
                                    .Element(ds + "Id").Value),
                                Name = entry.Element(atom + "content")
                                    .Element(dsmd + "properties")
                                    .Element(ds + "Name").Value,
                                Email = entry.Element(atom + "content")
                                    .Element(dsmd + "properties")
                                    .Element(ds + "Email").Value,
                                BirthDate = entry.Element(atom + "content")
                                    .Element(dsmd + "properties")
                                    .Element(ds + "BirthDate").Value,
                                MobilePhone = entry.Element(atom + "content")
                                    .Element(dsmd + "properties")
                                    .Element(ds + "MobilePhone").Value,
                                Surname = entry.Element(atom + "content")
                                    .Element(dsmd + "properties")
                                    .Element(ds + "Surname").Value,
                                GivenName = entry.Element(atom + "content")
                                    .Element(dsmd + "properties")
                                    .Element(ds + "GivenName").Value
                            };
                        return contacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static object GetOdataObjectByName(string name)
        {
            try
            {
                var authRequest = HttpWebRequest.Create(authServiceUtri) as HttpWebRequest;
                authRequest.Method = "POST";
                authRequest.ContentType = "application/json";
                var bpmCookieContainer = new CookieContainer();
                authRequest.CookieContainer = bpmCookieContainer;
                string userName = "Supervisor";
                string userPassword = "Supervisor";
                using (var requesrStream = authRequest.GetRequestStream())
                {
                    using (var writer = new StreamWriter(requesrStream))
                    {
                        writer.Write(@"{
                                ""UserName"":""" + userName + @""",
                                ""UserPassword"":""" + userPassword + @""",
                                ""SolutionName"":""TSBpm"",
                                ""TimeZoneOffset"":-120,
                                ""Language"":""Ru-ru""
                                }");
                    }
                }
                using (var response = (HttpWebResponse)authRequest.GetResponse())
                {
                    var dataRequest =
                        HttpWebRequest.Create(serverUri + "ContactCollection?$filter= Name eq '" + name + "'")
                            as HttpWebRequest;
                    dataRequest.Method = "GET";
                    dataRequest.CookieContainer = bpmCookieContainer;
                    using (var dataResponse = (HttpWebResponse)dataRequest.GetResponse())
                    {

                        XDocument xmlDoc = XDocument.Load(dataResponse.GetResponseStream());
                        var contacts = from entry in xmlDoc.Descendants(atom + "entry")
                                       select new
                                       {
                                           Id = new Guid(entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Id").Value),
                                           Name = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Name").Value,
                                           Email = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Email").Value,
                                           BirthDate = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "BirthDate").Value,
                                           MobilePhone = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "MobilePhone").Value,
                                           Surname = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Surname").Value
                                       };
                        return contacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static object GetOdataObjectByNameSurname(NameHelper nameHelper)
        {
            try
            {
                var authRequest = HttpWebRequest.Create(authServiceUtri) as HttpWebRequest;
                authRequest.Method = "POST";
                authRequest.ContentType = "application/json";
                var bpmCookieContainer = new CookieContainer();
                authRequest.CookieContainer = bpmCookieContainer;
                string userName = "Supervisor";
                string userPassword = "Supervisor";
                using (var requesrStream = authRequest.GetRequestStream())
                {
                    using (var writer = new StreamWriter(requesrStream))
                    {
                        writer.Write(@"{
                                ""UserName"":""" + userName + @""",
                                ""UserPassword"":""" + userPassword + @""",
                                ""SolutionName"":""TSBpm"",
                                ""TimeZoneOffset"":-120,
                                ""Language"":""Ru-ru""
                                }");
                    }
                }
                using (var response = (HttpWebResponse)authRequest.GetResponse())
                {
                    Contact a = new Contact();
                    var dataRequest =
                        HttpWebRequest.Create(serverUri + "ContactCollection?$filter= GivenName eq '" + nameHelper.GivenName + "'" +" and Surname eq '"+nameHelper.Surname+"'")
                            as HttpWebRequest;
                    dataRequest.Method = "GET";
                    dataRequest.CookieContainer = bpmCookieContainer;
                    using (var dataResponse = (HttpWebResponse)dataRequest.GetResponse())
                    {

                        XDocument xmlDoc = XDocument.Load(dataResponse.GetResponseStream());
                        var contacts = from entry in xmlDoc.Descendants(atom + "entry")
                                       select new
                                       {
                                           Id = new Guid(entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Id").Value),
                                           Name = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Name").Value,
                                           Email = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Email").Value,
                                           BirthDate = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "BirthDate").Value,
                                           MobilePhone = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "MobilePhone").Value,
                                           Surname = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Surname").Value,
                                           GivenName = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "GivenName").Value
                                       };
                        return contacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static object GetOdataObjectBySurnameName(NameHelper nameHelper)
        {
            try
            {
                var authRequest = HttpWebRequest.Create(authServiceUtri) as HttpWebRequest;
                authRequest.Method = "POST";
                authRequest.ContentType = "application/json";
                var bpmCookieContainer = new CookieContainer();
                authRequest.CookieContainer = bpmCookieContainer;
                string userName = "Supervisor";
                string userPassword = "Supervisor";
                using (var requesrStream = authRequest.GetRequestStream())
                {
                    using (var writer = new StreamWriter(requesrStream))
                    {
                        writer.Write(@"{
                                ""UserName"":""" + userName + @""",
                                ""UserPassword"":""" + userPassword + @""",
                                ""SolutionName"":""TSBpm"",
                                ""TimeZoneOffset"":-120,
                                ""Language"":""Ru-ru""
                                }");
                    }
                }
                using (var response = (HttpWebResponse)authRequest.GetResponse())
                {
                    var dataRequest =
                        HttpWebRequest.Create(serverUri + "ContactCollection?$filter= Surname eq '" + nameHelper.Surname + "'" + " and GivenName eq '" + nameHelper.GivenName + "'")
                            as HttpWebRequest;
                    dataRequest.Method = "GET";
                    dataRequest.CookieContainer = bpmCookieContainer;
                    using (var dataResponse = (HttpWebResponse)dataRequest.GetResponse())
                    {

                        XDocument xmlDoc = XDocument.Load(dataResponse.GetResponseStream());
                        var contacts = from entry in xmlDoc.Descendants(atom + "entry")
                                       select new
                                       {
                                           Id = new Guid(entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Id").Value),
                                           Name = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Name").Value,
                                           Email = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Email").Value,
                                           BirthDate = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "BirthDate").Value,
                                           MobilePhone = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "MobilePhone").Value,
                                           Surname = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Surname").Value,
                                           GivenName = entry.Element(atom + "content")
                                                .Element(dsmd + "properties")
                                                .Element(ds + "GivenName").Value
                                       };
                        return contacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static object GetOdataObjectByNameMiddle(NameHelper nameHelper)
        {
            try
            {
                var authRequest = HttpWebRequest.Create(authServiceUtri) as HttpWebRequest;
                authRequest.Method = "POST";
                authRequest.ContentType = "application/json";
                var bpmCookieContainer = new CookieContainer();
                authRequest.CookieContainer = bpmCookieContainer;
                string userName = "Supervisor";
                string userPassword = "Supervisor";
                using (var requesrStream = authRequest.GetRequestStream())
                {
                    using (var writer = new StreamWriter(requesrStream))
                    {
                        writer.Write(@"{
                                ""UserName"":""" + userName + @""",
                                ""UserPassword"":""" + userPassword + @""",
                                ""SolutionName"":""TSBpm"",
                                ""TimeZoneOffset"":-120,
                                ""Language"":""Ru-ru""
                                }");
                    }
                }
                using (var response = (HttpWebResponse)authRequest.GetResponse())
                {
                    var dataRequest =
                        HttpWebRequest.Create(serverUri + "ContactCollection?$filter= MiddleName eq '" + nameHelper.MiddleName + "'"+" and GivenName eq '"+nameHelper.GivenName+"'")
                            as HttpWebRequest;
                    dataRequest.Method = "GET";
                    dataRequest.CookieContainer = bpmCookieContainer;
                    using (var dataResponse = (HttpWebResponse)dataRequest.GetResponse())
                    {

                        XDocument xmlDoc = XDocument.Load(dataResponse.GetResponseStream());
                        var contacts = from entry in xmlDoc.Descendants(atom + "entry")
                                       select new
                                       {
                                           Id = new Guid(entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Id").Value),
                                           Name = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Name").Value,
                                           Email = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Email").Value,
                                           BirthDate = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "BirthDate").Value,
                                           MobilePhone = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "MobilePhone").Value,
                                           Surname = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Surname").Value
                                       };
                        return contacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static object GetOdataObjectByAll()
        {
            try
            {
                var authRequest = HttpWebRequest.Create(authServiceUtri) as HttpWebRequest;
                authRequest.Method = "POST";
                authRequest.ContentType = "application/json";
                var bpmCookieContainer = new CookieContainer();
                authRequest.CookieContainer = bpmCookieContainer;
                string userName = "Supervisor";
                string userPassword = "Supervisor";
                using (var requesrStream = authRequest.GetRequestStream())
                {
                    using (var writer = new StreamWriter(requesrStream))
                    {
                        writer.Write(@"{
                                ""UserName"":""" + userName + @""",
                                ""UserPassword"":""" + userPassword + @""",
                                ""SolutionName"":""TSBpm"",
                                ""TimeZoneOffset"":-120,
                                ""Language"":""Ru-ru""
                                }");
                    }
                }
                using (var response = (HttpWebResponse)authRequest.GetResponse())
                {
                    var dataRequest =
                        HttpWebRequest.Create(serverUri + "ContactCollection?select=id, Name, Email, MobilePhone, Surname, BirthDate, GivenName")
                            as HttpWebRequest;
                    dataRequest.Method = "GET";
                    dataRequest.CookieContainer = bpmCookieContainer;
                    using (var dataResponse = (HttpWebResponse)dataRequest.GetResponse())
                    {

                        XDocument xmlDoc = XDocument.Load(dataResponse.GetResponseStream());
                        var contacts = from entry in xmlDoc.Descendants(atom + "entry")
                                       select new
                                       {
                                           Id = new Guid(entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Id").Value),
                                           Name = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Name").Value,
                                           Email = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Email").Value,
                                           BirthDate = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "BirthDate").Value,
                                           MobilePhone = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "MobilePhone").Value,
                                           Surname = entry.Element(atom + "content")
                                               .Element(dsmd + "properties")
                                               .Element(ds + "Surname").Value,
                                           GivenName = entry.Element(atom + "content")
                                                .Element(dsmd + "properties")
                                                .Element(ds + "GivenName").Value
                                       };
                        return contacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        } 
        public static void DeleteBpmEntityByOdataHttp(string contactId, out string message)
        {
            message = "";

            try
            {
                var request = (HttpWebRequest)HttpWebRequest.Create(serverUri
                        + "ContactCollection(guid'" + contactId + "')");
                request.Credentials = new NetworkCredential("Supervisor", "Supervisor");
                request.Method = "DELETE";
                using (WebResponse response = request.GetResponse())
                {
                    if (((HttpWebResponse)response).StatusCode == HttpStatusCode.Created)
                    {
                        message = "Delete is ok";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
