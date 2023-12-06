using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagram4Tables.Models
{
    

        public class DiagramItemLocal
        {

            public string ID { set; get; }
            public string ContainerID { set; get; }
        public long? colorResult { set; get; }

        public string Type { set; get; }
            public string Text { set; get; }
            public long? NoColor { set; get; }
            public long? YesColor { set; get; }
            public double X { set; get; }
            public double Y { set; get; }
            public Double Width { get; set; }
            public double Height { set; get; }


            public DiagramItemLocal(string id, string containerId, string type, string text, long noColor, long yesColor, double x, double y, double width, double height)
            {

                ID = id;
                ContainerID = containerId;
                Type = type;
                Text = text;
                NoColor = noColor;
                YesColor = yesColor;
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }

            public DiagramItemLocal() { }

        }

        public class Edge
        {
            public string Key { get; set; }
            public string Text { get; set; }
            public string FromKey { get; set; }
            public string ToKey { get; set; }

            public Edge(string key, string text, string fromKey, string toKey)
            {
                Key = key;
                Text = text;
                FromKey = fromKey;
                ToKey = toKey;

            }




        }
    }
