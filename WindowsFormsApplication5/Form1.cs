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
        string comment1 = "Возможные предвестники бронхиальной астмы. Дать рекомендации по профилактике.";
        string comment2 = "Работник имеет признаки респираторного неблагополучия. Подозрение на наличие диагноза \"бронхиальная астма\".";
        string comment3 = "Работник имеет признаки респираторного неблагополучия. Диагноз \"бронхиальная астма\" возможен, но необходимо провести детальную дифференциальную диагностику.";
        string comment4 = "Повышенный риск развития бронхиальной астмы. Дать рекомендации по профилактике.";
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

            string comment = "";

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
            if (checkBox18.Checked)
            {
                UCondition = true;
                //comment += System.Environment.NewLine + comment4;
            }
            //проверка ф
            bool FCondition = false;
            if (checkBox19.Checked)
            {
                FCondition = true;
                //comment += System.Environment.NewLine + comment5;
            }

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

            //при отсутствии ненужных галочек и а-е и мб ф,у
            if (a_e_f_u == true && withoutOtherExcept_a_e > 0)
            {
                firstCondition = true;
                comment += System.Environment.NewLine + comment1;
            }             
                

            //Только ж-л (более 1 пункта) либо ж-л (более 1 пункта) 
            //в сочетании с а-е (в сочетании с у и/или ф или без него)
            bool secondCondition = false;
            int punkt = 0;
            for (int i = 1; i <= 5; i++)
            {
                if (cBs[i].Checked || (cBs[i].Checked && cBs[i + 9].Checked &&
                    cBs[15].Checked)) punkt++;
            }
            if (punkt > 1 || (a_e_f_u == true && punkt > 1))
            {
                comment += System.Environment.NewLine + comment2;
                secondCondition = true;
            }

            //Ж-л в сочетании м-т (независимо от наличия или отсутствия а-е, 
            //в сочетании с у и/или ф или без него) 
            bool thirdCondition = false;
            bool w = false;
            if (cBs[16].Checked || cBs[17].Checked) w = true;

            for (int i = 1; i <= 9; i++)
            {
                if (cBs[i].Checked || w && cBs[i].Checked) thirdCondition = true;
            }
            if (thirdCondition) comment += System.Environment.NewLine + comment3;

            if (UCondition) comment += System.Environment.NewLine + comment4;
            if (FCondition) comment += System.Environment.NewLine + comment5;

            //Только м-т (в сочетании с у и/или ф или без него)
            bool sixthCondition = false;
            for (int i = 6; i <= 9; i++)
            {
                if (cBs[i].Checked && w || cBs[i].Checked)
                {
                    for (int k = 1; k < 6; k++)
                    {
                        if (cBs[k].Checked == false && cBs[k + 9].Checked == false)
                            sixthCondition = true;
                    }
                }
            }
            if (sixthCondition) comment += System.Environment.NewLine + comment6;

            if (checkBox19.Checked == false) comment += System.Environment.NewLine +
                    System.Environment.NewLine + commentNotF;                    

            textBox8.Text = comment;
            if (textBox8.Text != "") button2.Enabled = true;


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
