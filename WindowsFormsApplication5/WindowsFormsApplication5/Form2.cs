using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    // Specify that the link was visited.
        //    this.linkLabel1.LinkVisited = true;

        //    // Navigate to a URL.
        //    //System.Diagnostics.Process.Start("http://www.microsoft.com");
        //    System.Diagnostics.Process.Start("http://www.consultant.ru/document/cons_doc_LAW_32716/#dst100030");
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();        
            Form f1 = new Form1();
            //if (f1.)
            f1.Activate();
            //f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Dictionary<int, string> privData = new Dictionary<int, string>();
            //privData.Add(1, D.FIO);
            //privData.Add(2, D.sex);
            //privData.Add(3, D.age);
            //privData.Add(4, D.experience);
            //privData.Add(5, D.company);
            //privData.Add(6, D.department);
            //privData.Add(7, D.profession);
            //privData.Add(0, D.factors);
            //string[] privData = new string[8] { D.FIO, D.sex, D.age, D.experience,
            //    D.company, D.department, D.profession, D.factors};

            //string[] marks = new string[8] { "FIO", "sex", "age", "experience" ,
            //"company", "department", "profession", "factors"};
            //marks[1] = "FIO";
            //marks[2] = "sex";
            //marks[3] = "age";
            //marks[4] = "experience";
            //marks[5] = "company";
            //marks[6] = "department";
            //marks[7] = "profession";
            //marks[0] = "factors";

            poisk("извещение 1");

            
        }

        public void poisk(string izvech)
        {
            string[] marks = new string[8] { "FIO", "sex", "age", "experience" ,
            "company", "department", "profession", "factors"};
            string[] privData = new string[8] { D.FIO, D.sex, D.age, D.experience,
                D.company, D.department, D.profession, D.factors};


            Microsoft.Office.Interop.Word.Application application;
            Microsoft.Office.Interop.Word.Document document;

            Object missingObj = System.Reflection.Missing.Value;
            Object trueObj = true;
            Object falseObj = false;

            application = new Microsoft.Office.Interop.Word.Application();
            string exeDir = 
                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Object pathObj = System.IO.Path.Combine(exeDir, izvech);

            try
            {
                document = application.Documents.Add(ref pathObj, ref missingObj,
                    ref missingObj, true);
            }
            catch (Exception error)
            {
                //document.Close(ref falseObj, ref missingObj, ref missingObj);
                application.Quit(ref falseObj, ref missingObj, ref missingObj);
                document = null;
                application = null;
                throw error;
            }
            application.Visible = true;            

            // обьектные строки для Word
            //object strToFind = null;
            //object replaceStr = null;
            object strToFindObj; // = strToFind;            
            object replaceStrObj; //= replaceStr;
            // диапазон документа Word
            Microsoft.Office.Interop.Word.Range wordRange;
            //тип поиска и замены
            object replaceTypeObj;
            replaceTypeObj = WdReplace.wdReplaceAll;

            //object bookmarkNameObj = "department";

            //заменяем по очереди нужные слова
            for (int j=0; j<8; j++)
            {

                if (marks[j] == "FIO" || marks[j] == "company" ||
                    marks[j] == "department" || marks[j] == "factors")
                {
                    int x = 66 - privData[j].Length;
                    for (int z = 1; z <= x; z++) privData[j] += "_";
                }
                strToFindObj = marks[j];
                replaceStrObj = privData[j];


                // обходим все разделы документа
                for (int i = 1; i <= document.Sections.Count; i++)
                {
                    // берем всю секцию диапазоном
                    wordRange = document.Sections[i].Range;                    

                    Microsoft.Office.Interop.Word.Find wordFindObj = wordRange.Find;                    

                    object[] wordFindParameters = new object[15]
                    { strToFindObj, missingObj, missingObj, missingObj, missingObj, missingObj,
                    missingObj, missingObj, missingObj, replaceStrObj, replaceTypeObj, missingObj,
                    missingObj, missingObj, missingObj };

                    wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, 
                        null, wordFindObj, wordFindParameters);
                }
            }
            
            
        }
    }
}
