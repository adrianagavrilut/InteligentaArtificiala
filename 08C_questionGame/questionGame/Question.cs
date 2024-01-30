using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace questionGame
{
    public class Points
    {
        public string Answers;
        public int points;

        public Points(string Answers, int points)
        {
            this.Answers = Answers;
            this.points = points;
        }
        public Points() { }
    }

    public class Question
    {
        public string Title;
        public List<string> Domain;
        public int Level;

        public List<string> Body;
        public Image Image;
        public string ImageSource;
        public List <string> Answers;
        public List <Points> CorrectAnswers;

        public Question()
        {
            Domain = new List<string> ();
            Body = new List<string>();
            Answers = new List<string>();
            CorrectAnswers = new List<Points>();
        }
    }
}
