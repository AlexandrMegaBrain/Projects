using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TBotBPM.BPM;

namespace TBotBPM
{
    static class Commander
    {
        public static bool IsCommandSurname(string text)
        {
            string pattern = @"/(.*?) \b(.*?)\b";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            return mc.Count > 0 && text.Count(x=>x==' ')==1 ? true : false;
        }
        public static bool IsCommandName(string text)
        {
            string pattern = @"/(\w+) \b(\w+)\b \b(\w+)\b \b(\w+)\b";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            int g3 = 0;
            int g4 = 0;
            foreach (Match x in mc)
            {
                if (x.Groups[3].Value != "")
                {
                    g3++;
                }
                if (x.Groups[4].Value != "")
                {
                    g4++;
                }
            }
            return mc.Count> 0 && g3!=0 && g4!=0? true : false;
        }
        public static bool IsCommandNameSurnameSurnameNameNameMidleName(string text)
        {
            string pattern = @"/(\w+) \b(\w+)\b \b(\w+)\b";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            return mc.Count > 0 && text.Count(x => x == ' ') == 2 ? true : false;
        }
        public static string Command(string text)
        {
            string pattern = @"/(.*?) ";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            string temp = "";
            foreach (Match x in mc)
            {
                temp=x.Groups[1].Value;
            }
            return temp;
        }
        public static NameHelper GetSurnameCommand(string text)
        {
            string pattern = @"/(\w+) \b(\w+)\b";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            NameHelper nameHelper= new NameHelper();
            foreach (Match x in mc)
            {
                nameHelper.Surname = x.Groups[2].Value;
            }
            return nameHelper;
        }
        public static NameHelper GetNameCommand(string text)
        {
            string pattern = @"/(\w+) \b(\w+)\b \b(\w+)\b \b(\w+)\b";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            NameHelper nameHelper= new NameHelper();
            foreach (Match x in mc)
            {
                nameHelper.Name= x.Groups[2].Value +" "+ x.Groups[3].Value+" "+ x.Groups[4].Value;
            }
            return nameHelper;
        }
        public static NameHelper GetNameSurnameCommand(string text)
        {
            string pattern = @"/(.*?) \b(.*?)\b \b(.*?)\b";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            NameHelper nameHelper= new NameHelper();
            foreach (Match x in mc)
            {
                nameHelper.GivenName = x.Groups[2].Value;
                nameHelper.Surname = x.Groups[3].Value;
            }
            return nameHelper;
        }
        public static NameHelper GetSurnameNameCommand(string text)
        {
            string pattern = @"/(\w+) \b(\w+)\b \b(\w+)\b";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            NameHelper nameHelper = new NameHelper();
            foreach (Match x in mc)
            {
                nameHelper.GivenName = x.Groups[3].Value;
                nameHelper.Surname = x.Groups[2].Value;
            }
            return nameHelper;
        }
        public static NameHelper GetNameMiddle(string text)
        {
            string pattern = @"/(\w+) \b(\w+)\b \b(\w+)\b";
            Regex regex = new Regex(pattern);
            MatchCollection mc = regex.Matches(text);
            NameHelper nameHelper = new NameHelper();
            foreach (Match x in mc)
            {
                nameHelper.GivenName = x.Groups[2].Value;
                nameHelper.MiddleName = x.Groups[3].Value;
            }
            return nameHelper;
        }
    }
}
