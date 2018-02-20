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
            Microsoft.Office.Interop.Word.Application application;
            Microsoft.Office.Interop.Word.Document document;

            Object missingObj = System.Reflection.Missing.Value;
            Object trueObj = true;
            Object falseObj = false;

            application = new Microsoft.Office.Interop.Word.Application();
            Object pathObj = "извещение 1";

            try
            {
                document = application.Documents.Add(ref pathObj, ref missingObj, 
                    ref missingObj, true);
            }
            catch (Exception error)
            {
                document.Close(ref falseObj, ref missingObj, ref missingObj);
                application.Quit(ref falseObj, ref missingObj, ref missingObj);
                document = null;
                application = null;
                throw error;
            }
            application.Visible = true;

            // обьектные строки для Word
            object strToFind = null;
            object strToFindObj = strToFind;
            object replaceStr = null;
            object replaceStrObj = replaceStr;
            // диапазон документа Word
            Microsoft.Office.Interop.Word.Range wordRange;
            //тип поиска и замены
            object replaceTypeObj;
            replaceTypeObj = WdReplace.wdReplaceAll;
            // обходим все разделы документа
            for (int i = 1; i <= document.Sections.Count; i++)
            {
                // берем всю секцию диапазоном
                wordRange = document.Sections[i].Range;

                /*
                Обходим редкий глюк в Find, ПРИЗНАННЫЙ MICROSOFT, метод Execute на некоторых машинах вылетает с ошибкой "Заглушке переданы неправильные данные / Stub received bad data"  Подробности: http://support.microsoft.com/default.aspx?scid=kb;en-us;313104
                // выполняем метод поиска и  замены обьекта диапазона ворд
                wordRange.Find.Execute(ref strToFindObj, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref replaceStrObj, ref replaceTypeObj, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing);
                */

                Microsoft.Office.Interop.Word.Find wordFindObj = wordRange.Find;
                object[] wordFindParameters = new object[15] 
                { strToFindObj, missingObj, missingObj, missingObj, missingObj, missingObj,
                    missingObj, missingObj, missingObj, replaceStrObj, replaceTypeObj, missingObj,
                    missingObj, missingObj, missingObj };

                wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);
            }


        }
    }
}
