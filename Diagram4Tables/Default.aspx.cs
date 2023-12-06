using DevExpress.Web.ASPxDiagram;
using Diagram4Tables.Data;
using Diagram4Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diagram4Tables {
    public partial class _Default : System.Web.UI.Page {
        List<DiagramItemLocal> Items = new List<DiagramItemLocal>();


        static DbContextForDiagram _db = new DbContextForDiagram();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateDiagram();
            }

        }



        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               GenerateDiagram();

            }
        }




        protected void GenerateDiagram()
        {
            List<SETUP_MTS_GROUP> groups = new List<SETUP_MTS_GROUP>();
            groups = _db.SETUP_MTS_GROUP.ToList();

            List<SETUP_MTS_GROUP_QUESTION> groupquestions = new List<SETUP_MTS_GROUP_QUESTION>();
            groupquestions = _db.SETUP_MTS_GROUP_QUESTION.ToList();


            List<DiagramItemLocal> Items = new List<DiagramItemLocal>();
            List<Edge> Edges = new List<Edge>();



            var sortedQuestions = from q in groupquestions
                                  join g in groups on q.GroupID equals g.ID
                                  orderby g.GroupOrder, q.QuestionOrder
                                  select q;
            List<SETUP_MTS_GROUP_QUESTION> sortedQuestionList = sortedQuestions.ToList();



            int groupscounter = 0;
            string IdForThePrevQuestionGroup=null; // used to know whether the question in the previous question group or not.
            double prevQuestionY = 0;
            int numberOfQuestionsInEachGroup = 0;
            DiagramItemLocal VerticalContaineritem = null;
            foreach (SETUP_MTS_GROUP_QUESTION q in sortedQuestionList)
            {
                if ((groupscounter == 0 || (IdForThePrevQuestionGroup != q.GroupID)))
                {
                    DiagramItemLocal prevContainer = Items.Where(p => p.ID == IdForThePrevQuestionGroup + "").FirstOrDefault();

                    if (IdForThePrevQuestionGroup != q.GroupID && VerticalContaineritem != null)
                    {
                        prevQuestionY = prevQuestionY + 1.5;
                        prevContainer.Height = numberOfQuestionsInEachGroup * 0.85 + 0.25;
                        numberOfQuestionsInEachGroup = 0;

                        DiagramItemLocal EllipseToEdit = Items.Where(l => l.ID == "Ellipsey" + prevContainer.ID).FirstOrDefault();
                        EllipseToEdit.Y = prevContainer.Y + prevContainer.Height / 2 - 0.5;
                    }

                    SETUP_MTS_GROUP questionGroup = groups.Where(g => g.ID == q.GroupID).FirstOrDefault();
                    if (prevContainer != null)
                    {
                        VerticalContaineritem = new DiagramItemLocal() { 
                        ID = questionGroup.ID,
                        Type= DiagramShapeType.VerticalContainer.ToString(),
                        Text= questionGroup.GroupName,
                        NoColor= questionGroup.GroupNoResult,
                        YesColor = questionGroup.GroupYesResult,
                        X= 1.5,
                        Y= prevContainer.Y + prevContainer.Height + 1,
                        Width=3.5,

                        };


                           
                    }
                    else
                    {

                        VerticalContaineritem = new DiagramItemLocal()
                        {
                            ID = questionGroup.ID,
                            Type = DiagramShapeType.VerticalContainer.ToString(),
                            Text = questionGroup.GroupName,
                            NoColor = questionGroup.GroupNoResult,
                            YesColor = questionGroup.GroupYesResult,
                            X = 1.5,
                            Y = 1.5,
                            Width = 3.5,
                        };
                        prevQuestionY = prevQuestionY + VerticalContaineritem.Y + 0.5;

                    }



                    Items.Add(VerticalContaineritem);
                    DiagramItemLocal YesEllipse = new DiagramItemLocal()
                    {
                        ID = "Ellipsey" + questionGroup.ID,
                        Type = DiagramShapeType.Ellipse.ToString(),
                        colorResult= questionGroup.GroupYesResult,
                        X = VerticalContaineritem.X + VerticalContaineritem.Width + 1.5,
                        Y = VerticalContaineritem.Y + VerticalContaineritem.Height / 2 - 0.5,
                        Width = 1,
                        Height=1

                    };
                   

                    Items.Add(YesEllipse);

                    Edge YesEdge = new Edge("Edgey" + questionGroup.ID, "Yes", questionGroup.ID + "", YesEllipse.ID);
                    Edges.Add(YesEdge);
                    if (groupscounter != 0)
                    {
                        Edge EdgeBetweenGroups = new Edge("Edgen" + VerticalContaineritem.ID, "No", IdForThePrevQuestionGroup + "", VerticalContaineritem.ID);
                        Edges.Add(EdgeBetweenGroups);
                    }
                    groupscounter++;
                    IdForThePrevQuestionGroup = q.GroupID;
                }
                string QuestionText = _db.SETUP_MTS_QUESTION.Where(qt => qt.ID == q.QuestionID).FirstOrDefault().QuestionText;


                DiagramItemLocal ContainerQuestion = new DiagramItemLocal()
                {
                    ID = "q" + q.ID,
                    ContainerID = q.GroupID,

                    Type = DiagramShapeType.Text.ToString(),
                    Text = QuestionText,
                    X = VerticalContaineritem.X + 0.25,
                    Y = prevQuestionY,
                    Width = VerticalContaineritem.Width - 0.5,
                    Height = 0.5

                };
                prevQuestionY = prevQuestionY + 0.75;

                Items.Add(ContainerQuestion);

                numberOfQuestionsInEachGroup++;


            }

            DiagramItemLocal LastVerticalContainer = Items.Where(l => l.ID == "" + IdForThePrevQuestionGroup).FirstOrDefault();
            LastVerticalContainer.Height = numberOfQuestionsInEachGroup * 0.85 + 0.25;

            DiagramItemLocal NoEllipse2 = new DiagramItemLocal()
            {
                ID = "Ellipsen" + IdForThePrevQuestionGroup,
                Type = DiagramShapeType.Ellipse.ToString(),
                colorResult = LastVerticalContainer.NoColor,
                X = LastVerticalContainer.X + LastVerticalContainer.Width / 2 - 0.5,
                Y = LastVerticalContainer.Y + LastVerticalContainer.Height + 1,
                Width = 1,
                Height = 1

            };
           
            numberOfQuestionsInEachGroup = 0;

            DiagramItemLocal LastYesEllpise = Items.Where(l => l.ID == "Ellipsey" + LastVerticalContainer.ID).FirstOrDefault();
            LastYesEllpise.Y = LastVerticalContainer.Y + LastVerticalContainer.Height / 2 - 0.5;

            Edge LastNoEdge = new Edge("Edgen" + LastVerticalContainer.ID, "No", LastVerticalContainer.ID + "", NoEllipse2.ID + "");
            Edges.Add(LastNoEdge);
            Items.Add(NoEllipse2);


            Diagram.EdgeDataSource = Edges;
            Diagram.NodeDataSource = Items;
            Diagram.DataBind();
            this.Items = Items;
        }


        protected void Diagram_NodeDataBound1(object sender, DevExpress.Web.ASPxDiagram.DiagramNodeEventArgs e)
        {
            DevExpress.Web.ASPxDiagram.DiagramNode N = e.Node;
            DiagramItemLocal itemForThisNode = Items.Where(n => n.ID == e.Node.Key + "").FirstOrDefault();

            if (e.Node.Type.ToString() == DiagramShapeType.Ellipse.ToString() && itemForThisNode != null)
            {
                e.Node.Style = "fill:" + itemForThisNode.YesColor;
            }

        }



    }


}