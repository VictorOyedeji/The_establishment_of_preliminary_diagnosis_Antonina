using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        //int tests_acsess = 0;
        string comment1 = "Возможные предвестники бронхиальной астмы или сопутствующие состояния при наличии бронхиальной астмы.";
        string comment2 = "Работник имеет признаки респираторного неблагополучия. Диагноз \"бронхиальная астма\" вероятен.";
        string comment3 = "Работник имеет признаки респираторного неблагополучия. Диагноз \"бронхиальная астма\" возможен, но необходимо провести детальную дифференциальную диагностику.";
        string comment4 = "Имеется повышенный риск развития бронхиальной астмы.";
        string comment5 = "При наличии бронхиальной астмы возможна связь заболевания с профессией.";
        string comment6 = "Работник не имеет значимых жалоб со стороны респираторного тракта. ";
        string commentNotF = "Установить связь заболевания с профессией невозможно ввиду отсутствия контакта с индукторами и триггерами астмы на рабочем месте";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox8.Text = null;
            private_data();

            //string comment = "";

            if (checkBox5.Checked && checkBox9.Checked ||
                checkBox1.Checked && checkBox6.Checked ||
                checkBox4.Checked && checkBox6.Checked ||
                checkBox2.Checked && checkBox6.Checked)
            {
                MessageBox.Show(
                "Нельзя одновременно выбрать Л и Т, Ж и Н, К и Н, З и Н",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            Dictionary<int, CheckBox> cBs = new Dictionary<int, CheckBox>();
            cBs.Add(1, checkBox1);
            cBs.Add(2, checkBox2);
            cBs.Add(3, checkBox3);
            cBs.Add(4, checkBox4);
            cBs.Add(5, checkBox5);
            cBs.Add(6, checkBox6);
            cBs.Add(7, checkBox7);
            cBs.Add(8, checkBox8);
            cBs.Add(9, checkBox9);
            cBs.Add(10, checkBox10);
            cBs.Add(11, checkBox11);
            cBs.Add(12, checkBox12);
            cBs.Add(13, checkBox13);
            cBs.Add(14, checkBox14);
            cBs.Add(15, checkBox15);
            cBs.Add(16, checkBox16);
            cBs.Add(17, checkBox17);
            cBs.Add(18, checkBox18);
            cBs.Add(19, checkBox19);

            //проверка галочек
            int tickDoesntExist = 0;
            for (int i = 1; i <= 19; i++)
            {
                if (cBs[i].Checked == false) tickDoesntExist++;
            }
            if (tickDoesntExist == 19) MessageBox.Show("Hи одна жалоба не отмечена");

            //проверка у
            bool UCondition = false;
            if (checkBox18.Checked) UCondition = true;
            //проверка ф
            bool FCondition = false;
            if (checkBox19.Checked) FCondition = true;

            //Только а-е (в сочетании с у и/или ф или без него)
            bool firstCondition = false;
            int withoutOtherExcept_a_e = 0; // для проверки ненужных галочек
            bool a_e_f_u = false;   // как минимум а-е в сочетании с у и/или ф или без него
            int aefu = 0;
            // проверка ненужных галочек
            for (int q = 1; q <= 9; q++)
            {                
                if (cBs[q].Checked == false && cBs[16].Checked == false &&
                    cBs[17].Checked == false) withoutOtherExcept_a_e ++;                
            }
            //if (withoutOtherExcept_a_e > 0)
            //{
            //    //ТОЛЬКО а-у и мб ф,у
            //    for (int i = 10; i <= 15; i++)
            //    {
            //        if ((cBs[i].Checked && UCondition) || (cBs[i].Checked && FCondition) ||
            //            (cBs[i].Checked && UCondition && FCondition)) aefu++;
            //        if (aefu > 0) firstCondition = true; //a_e_f_u = true;
            //    }
            //}

            // как минимум а-е в сочетании с у и/или ф или без него
            for (int i = 10; i <= 15; i++)
            {
                if ((cBs[i].Checked && UCondition) || (cBs[i].Checked && FCondition) ||
                    (cBs[i].Checked && UCondition && FCondition) ||
                    cBs[i].Checked == true) aefu ++;
                if (aefu > 0) a_e_f_u = true;
            }

            //а-е и мб ф,у при отсутствии ненужных галочек
            if (a_e_f_u == true && withoutOtherExcept_a_e == 9)
                firstCondition = true;
                //comment += System.Environment.NewLine + comment1;        
                

            //Только ж-л (более 1 пункта) либо ж-л (более 1 пункта) 
            //в сочетании с а-е (в сочетании с у и/или ф или без него)
            bool secondCondition = false;
            int jl = 0;
            for (int i = 1; i <= 5; i++)
            {
                if (cBs[i].Checked || (cBs[i].Checked && cBs[i + 9].Checked &&
                    cBs[15].Checked)) jl++;
            } 
            for (int q=6; q<=9; q++)
            {
                if (cBs[q].Checked == false && cBs[16].Checked == false &&
                    cBs[17].Checked == false)
                {
                    if (jl > 1 || (a_e_f_u == true && jl > 1))
                    {
                        //comment += comment2;
                        secondCondition = true;
                    }
                }
            }           
            

            //Ж-л в сочетании м-т (независимо от наличия или отсутствия а-е, 
            //в сочетании с у и/или ф или без него) 
            bool thirdCondition = false;
            int mt = 0;
            for (int i = 6; i <= 9; i++)
            {
                if (cBs[i].Checked || cBs[16].Checked || cBs[17].Checked) mt++;
                if (mt > 0 && jl > 0) thirdCondition = true;
                //if (w > 0) thirdCondition = true;
            }            
                        

            //Только м-т (в сочетании с у и/или ф или без него)
            bool sixthCondition = false;
            int onlymt = 0;
            if (mt > 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (cBs[i].Checked == false && cBs[i + 9].Checked == false &&
                        cBs[15].Checked == false) onlymt++;
                }
                if (onlymt == 5) sixthCondition = true;
            }


            //вывод комментариев
            //bool dubl = false;
            if (UCondition) komment(comment4);
            if (firstCondition) komment(comment1);                                    
            if (secondCondition) komment(comment2);
            if (thirdCondition) komment(comment3);
            if (sixthCondition) komment(comment6);
            if (FCondition) komment(comment5);            
            if (FCondition == false) komment(System.Environment.NewLine + commentNotF);


            //При сочетании комментариев 2 и 5 либо 3 и 5 – показать текст и форму извещения
            //и открыть доступ к тестам
            if (secondCondition && FCondition || thirdCondition && FCondition)
            {
                //this.Hide();
                Form Form2 = new Form2();
                Form2.StartPosition = FormStartPosition.CenterParent;
                Form2.Show();
            }

        }

        private void komment( string s)
        {
            if (textBox8.Text != "") textBox8.Text += System.Environment.NewLine +
                    System.Environment.NewLine + s;
            else textBox8.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.Show();
        }

        public void private_data()
        {
            //D.FIO = textBox1.Text.ToString();
            //D.sex = comboBox1.SelectedItem.ToString();
            //D.age = textBox2.Text.ToString();
            //D.experience = textBox3.Text.ToString();
            //D.company = textBox4.Text.ToString();
            //D.department = textBox5.Text.ToString();
            //D.profession = textBox6.Text.ToString();
            //D.factors = textBox7.Text.ToString();
        }

    }

    public static class D
    {
        public static string FIO { get; set; }
        public static string sex { get; set; }
        public static string age { get; set; }
        public static string experience { get; set; }
        public static string company { get; set; }
        public static string department { get; set; }
        public static string profession { get; set; }
        public static string factors { get; set; }
    }
}
