using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace questionGame
{
    public static class Engine
    {

        public static List<Question> crtQuestions = new List<Question> ();
        public static int crtQuestionIDX = 0;
        public static Question crtQuestion;
        public static void initSession()
        {
        }

        public static void readXML(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/document/question");
            foreach (XmlNode node in nodeList) 
            {
                Question local = new Question();
                local.Title = node.SelectSingleNode("title").InnerText.Trim();
                XmlNodeList list_of_domains = node.SelectNodes("domain");
                foreach (XmlNode crt_domain in list_of_domains)
                    local.Domain.Add (crt_domain.InnerText.Trim());
                local.Level = int.Parse(node.SelectSingleNode("level").InnerText.Trim());
                string[] contentData = (node.SelectSingleNode("content").InnerText).Trim().Split('\n');
                foreach (string s in contentData)
                    local.Body.Add(s.Trim());

                local.Image = null;
                local.ImageSource = string.Empty;
                try
                {
                    if ((node.SelectSingleNode("image").InnerText.Trim()) != null)
                    {
                        string image_string = node.SelectSingleNode("image").InnerText.Trim();
                        local.Image = Image.FromFile(@"..\..\Resurse\Image\" + image_string);
                        local.ImageSource = node.SelectSingleNode("source").InnerText.Trim();
                    }

                }
                catch { }
                XmlNodeList list_of_answers = node.SelectNodes("answer");
                foreach (XmlNode crt_answer in list_of_answers)
                    local.Answers.Add(crt_answer.InnerText.Trim ());


                XmlNodeList list_of_Points = node.SelectNodes("correct");
                foreach (XmlNode crt_Point in list_of_Points)
                {
                    
                    string IDX = crt_Point.SelectSingleNode("var").InnerText.Trim();
                    int VAL = int.Parse (crt_Point.SelectSingleNode("points").InnerText.Trim());
                    Points A = new Points(IDX, VAL);
                    local.CorrectAnswers.Add(A);
                }

                crtQuestions.Add(local);
            }
        }

        public static void initDemo() 
        {
           
            readXML(@"../../Resurse/Intrebari/demo.xml");

            crtQuestion = crtQuestions[crtQuestionIDX];
        }

        public static void NextQuestion() 
        {
            crtQuestionIDX++;
            if (crtQuestionIDX >= crtQuestions.Count)
                crtQuestionIDX = 0;
            crtQuestion = crtQuestions[crtQuestionIDX];
        }
    }
}
