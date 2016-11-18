using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimpleJSON;
using TBotBPM.BPM;

namespace TBotBPM
{
    internal class TBot
    {
        public static string Token = @"294997053:AAGk99XOE2XQoqHz_Q2Llkha7C9ZdZLV2lo";
        public static int LastUpdateID = 0;

        public static void GetUpdates()
        {
            using (var webClient = new WebClient())
            {
                string response =
                    webClient.DownloadString("https://api.telegram.org/bot" + Token + "/getUpdates" + "?offset=" +
                                             (LastUpdateID + 1));

                var N = JSON.Parse(response);
                
                foreach (JSONNode r in N["result"].AsArray)
                {
                    LastUpdateID = r["update_id"].AsInt;                  
                    if (r["message"]["text"]!="")
                    {
                        int cs = 0;
                        if (Commander.IsCommandSurname(r["message"]["text"]))
                        {
                            if (Commander.Command(r["message"]["text"]) == "find")
                            {
                                object contacts =CRUD.GetOdataObjectBySurname(
                                        Commander.GetSurnameCommand(r["message"]["text"]).Surname);
                                cs = 0;
                                if (contacts != null)
                                {
                                    foreach (var x in (dynamic)contacts)
                                    {
                                        SendMessage(
                                            String.Format(
                                                "ФИО {0}\nДень рождения {1}\nМобильный телефон {2}\nEmail {3}\n",
                                                (dynamic) x.Name, (dynamic) x.BirthDate, (dynamic) x.MobilePhone,
                                                (dynamic) x.Email), r["message"]["chat"]["id"].AsInt);
                                    }
                                }
                                if (cs == 0)
                                {
                                    SendMessage("Нет такого пользователя", r["message"]["chat"]["id"].AsInt);
                                }
                            }
                            if (Commander.Command(r["message"]["text"]) == "delete")
                            {
                                object temp =
                                    CRUD.GetOdataObjectBySurname(
                                        Commander.GetSurnameCommand(r["message"]["text"]).Surname);
                                string message;
                                if (temp != null)
                                {
                                    foreach (var x in (dynamic) temp)
                                    {
                                        if ((dynamic) x.Surname == r["message"]["text"])
                                        {
                                            CRUD.DeleteBpmEntityByOdataHttp((dynamic) x.Id, out message);
                                            SendMessage(message, r["message"]["chat"]["id"].AsInt);
                                        }
                                    }
                                }
                            }
                        }
                        int cn;
                        if (Commander.IsCommandName(r["message"]["text"]))
                        {
                            if (Commander.Command(r["message"]["text"]) == "find")
                            {
                                object contacts = CRUD.GetOdataObjectByName(
                                        Commander.GetNameCommand(r["message"]["text"]).Name);
                                cn = 0;
                                if (contacts != null)
                                {
                                    foreach (var x in (dynamic)contacts)
                                    {
                                        SendMessage(
                                            String.Format(
                                                "ФИО {0}\nДень рождения {1}\nМобильный телефон {2}\nEmail {3}\n",
                                                (dynamic) x.Name, (dynamic) x.BirthDate, (dynamic) x.MobilePhone,
                                                (dynamic) x.Email), r["message"]["chat"]["id"].AsInt);
                                    }
                                }
                                if (cn == 0)
                                {
                                    SendMessage("Нет такого пользователя", r["message"]["chat"]["id"].AsInt);
                                }
                            }
                            if (Commander.Command(r["message"]["text"]) == "delete")
                            {
                                object temp =
                                    CRUD.GetOdataObjectByName(
                                        Commander.GetNameCommand(r["message"]["text"]).Name);
                                string message;
                                if (temp != null)
                                {
                                    foreach (var x in (dynamic)temp)
                                    {
                                        if ((dynamic)x.Surname == r["message"]["text"])
                                        {
                                            CRUD.DeleteBpmEntityByOdataHttp((dynamic)x.Id, out message);
                                            SendMessage(message, r["message"]["chat"]["id"].AsInt);
                                        }
                                    }
                                }
                            }
                        }
                        int cns=1;
                        if (Commander.IsCommandNameSurnameSurnameNameNameMidleName(r["message"]["text"]))
                        {
                            if (Commander.Command(r["message"]["text"]) == "find")
                            {
                                object contacts = CRUD.GetOdataObjectByNameSurname(
                                        Commander.GetNameSurnameCommand(r["message"]["text"]));
                                cns = 0;
                                if (contacts != null)
                                {
                                    foreach (var x in (dynamic)contacts)
                                    {
                                        cns++;
                                        SendMessage(
                                            String.Format(
                                                "ФИО {0}\nДень рождения {1}\nМобильный телефон {2}\nEmail {3}\n",
                                                (dynamic)x.Name, (dynamic)x.BirthDate, (dynamic)x.MobilePhone,
                                                (dynamic)x.Email), r["message"]["chat"]["id"].AsInt);
                                    }
                                }
                            }
                            if (Commander.Command(r["message"]["text"]) == "delete")
                            {
                                object temp =
                                    CRUD.GetOdataObjectByNameSurname(
                                        Commander.GetNameSurnameCommand(r["message"]["text"]));
                                string message;
                                if (temp != null)
                                {
                                    foreach (var x in (dynamic)temp)
                                    {
                                        if ((dynamic)x.Surname == r["message"]["text"])
                                        {
                                            CRUD.DeleteBpmEntityByOdataHttp((dynamic)x.Id, out message);
                                            SendMessage(message, r["message"]["chat"]["id"].AsInt);
                                        }
                                    }
                                }
                            }
                        }
                        int csn=1;
                        if(cns==0)
                        if (Commander.IsCommandNameSurnameSurnameNameNameMidleName(r["message"]["text"]))
                        {
                            if (Commander.Command(r["message"]["text"]) == "find")
                            {
                                csn = 0;
                                object contacts = CRUD.GetOdataObjectBySurnameName(
                                        Commander.GetSurnameNameCommand(Commander.Command(r["message"]["text"])));
                                if (contacts != null)
                                {
                                    foreach (var x in (dynamic)contacts)
                                    {
                                        csn++;
                                        SendMessage(
                                            String.Format(
                                                "ФИО {0}\nДень рождения {1}\nМобильный телефон {2}\nEmail {3}\n",
                                                (dynamic)x.Name, (dynamic)x.BirthDate, (dynamic)x.MobilePhone,
                                                (dynamic)x.Email), r["message"]["chat"]["id"].AsInt);
                                    }
                                }
                            }
                            if (Commander.Command(r["message"]["text"]) == "delete")
                            {
                                object temp =
                                    CRUD.GetOdataObjectBySurnameName(
                                        Commander.GetSurnameNameCommand(r["message"]["text"]));
                                string message;
                                if (temp != null)
                                {
                                    foreach (var x in (dynamic)temp)
                                    {
                                        if ((dynamic)x.Surname == r["message"]["text"])
                                        {
                                            CRUD.DeleteBpmEntityByOdataHttp((dynamic)x.Id, out message);
                                            SendMessage(message, r["message"]["chat"]["id"].AsInt);
                                        }
                                    }
                                }
                            }
                        }
                        int cnm = 1;
                        if(csn==0)
                        if (Commander.IsCommandNameSurnameSurnameNameNameMidleName(r["message"]["text"]))
                        {
                            if (Commander.Command(r["message"]["text"]) == "find")
                            {
                                object contacts = CRUD.GetOdataObjectByNameMiddle(
                                        Commander.GetNameMiddle(Commander.Command(r["message"]["text"])));
                                cnm = 0;
                                if (contacts != null)
                                {
                                    foreach (var x in (dynamic)contacts)
                                    {
                                        cnm++;
                                        SendMessage(
                                            String.Format(
                                                "ФИО {0}\nДень рождения {1}\nМобильный телефон {2}\nEmail {3}\n",
                                                (dynamic)x.Name, (dynamic)x.BirthDate, (dynamic)x.MobilePhone,
                                                (dynamic)x.Email), r["message"]["chat"]["id"].AsInt);
                                    }
                                }
                            }
                            if (Commander.Command(r["message"]["text"]) == "delete")
                            {
                                object temp =
                                    CRUD.GetOdataObjectByNameMiddle(
                                        Commander.GetNameMiddle(r["message"]["text"]));
                                string message;
                                if (temp != null)
                                {
                                    foreach (var x in (dynamic)temp)
                                    {
                                        if ((dynamic)x.Surname == r["message"]["text"])
                                        {
                                            CRUD.DeleteBpmEntityByOdataHttp((dynamic)x.Id, out message);
                                            SendMessage(message, r["message"]["chat"]["id"].AsInt);
                                        }
                                    }
                                }
                            }
                        }
                        if ((cns == 0) && (cnm == 0) && (csn == 0))
                        {
                            SendMessage("Нет такого пользователя!", r["message"]["chat"]["id"].AsInt);
                        }
                    }
                }
            }
        }

        public static void SendMessage(string message, int chatid)
        {
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();

                pars.Add("text", message);
                pars.Add("chat_id", chatid.ToString());

                webClient.UploadValues("https://api.telegram.org/bot" + Token + "/sendMessage", pars);
            }
        }
    }
}
