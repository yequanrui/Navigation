using System;
using System.Windows.Forms;

namespace Navigation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            createGraph();
            InitializeComponent();
            pictureInitialize(1);
            pictureInitialize(2);
        }
        int MAX = 20000;
        int distance = 0;
        public bool[,,] P = new bool[N, N, N];
        public int box = 0;//标注当前光标所在框的编号
        static int N = 17; //声明共有17个节点
        static int[] Vex_number = new int[N];//建立节点编号
        static string[] Vex_info = new string[N];//建立景点介绍信息
        static string[] Vex_sight = new string[N];//建立景点的名称信息
        static int[,] Arc_Legth = new int[N, N];//建立节点间的距离数组
        string[,] new_vexnum = new string[N, N];
        static int[] newPath_value = new int[N];//用于保存新的路线带权长度
        public void createGraph()
        {
            for (int i = 1; i < N; i++)
            {
                Vex_number[i] = i;
            }
            Vex_info[1] = "华南师范大学增城学院正门";
            Vex_info[2] = "学院图书馆，内有藏书百万册，以及电子文档等大量资料";
            Vex_info[3] = "学院主教楼，分A、B、C三栋";
            Vex_info[4] = "各系辅导员、科任老师、系主任、系党委书记办公室";
            Vex_info[5] = "学院新建的田径场，即足球场";
            Vex_info[6] = "包含多个篮球场";
            Vex_info[7] = "1号学生公寓（最大的男生宿舍）";
            Vex_info[8] = "一号饭堂，楼上是2号男生公寓";
            Vex_info[9] = "3号学生公寓（最大的女生宿舍）";
            Vex_info[10] = "校内的百货超市之一";
            Vex_info[11] = "华澳学院学生公寓及部分增院女生宿舍";
            Vex_info[12] = "男生宿舍及部分教师公寓";
            Vex_info[13] = "二号饭堂，楼上是女生宿舍";
            Vex_info[14] = "学院领导主要办公楼";
            Vex_info[15] = "校内比较好的饭堂，总共两层";
            Vex_info[16] = "校内唯一的湖泊,湖上有座桥";
            Vex_sight[1] = "学校正门";
            Vex_sight[2] = "图书馆";
            Vex_sight[3] = "教学楼";
            Vex_sight[4] = "第二行政楼";
            Vex_sight[5] = "田径场";
            Vex_sight[6] = "篮球场";
            Vex_sight[7] = "1栋宿舍";
            Vex_sight[8] = "一饭（2栋宿舍）";
            Vex_sight[9] = "3栋宿舍";
            Vex_sight[10] = "康大超市";
            Vex_sight[11] = "9-12栋宿舍";
            Vex_sight[12] = "13-16栋宿舍";
            Vex_sight[13] = "二饭（17-18栋宿舍）";
            Vex_sight[14] = "第一行政楼";
            Vex_sight[15] = "金穗饭堂";
            Vex_sight[16] = "小东湖";
        }
        private void pictureInitialize(int box)
        {
            if (box == 1)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                pictureBox11.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
                pictureBox15.Visible = false;
                pictureBox16.Visible = false;
            }
            if (box == 2)
            {
                pictureBox17.Visible = false;
                pictureBox18.Visible = false;
                pictureBox19.Visible = false;
                pictureBox20.Visible = false;
                pictureBox21.Visible = false;
                pictureBox22.Visible = false;
                pictureBox23.Visible = false;
                pictureBox24.Visible = false;
                pictureBox25.Visible = false;
                pictureBox26.Visible = false;
                pictureBox27.Visible = false;
                pictureBox28.Visible = false;
                pictureBox29.Visible = false;
                pictureBox30.Visible = false;
                pictureBox31.Visible = false;
                pictureBox32.Visible = false;
            }
        }
        //绘制地标点//
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            box = 1;
            pictureInitialize(1);
            if (comboBox1.Text == "学校正门") { display(Vex_number[1]); pictureBox1.Visible = true; }
            if (comboBox1.Text == "图书馆") { display(Vex_number[2]); pictureBox2.Visible = true; }
            if (comboBox1.Text == "教学楼") { display(Vex_number[3]); pictureBox3.Visible = true; }
            if (comboBox1.Text == "第二行政楼") { display(Vex_number[4]); pictureBox4.Visible = true; }
            if (comboBox1.Text == "田径场") { display(Vex_number[5]); pictureBox5.Visible = true; }
            if (comboBox1.Text == "篮球场") { display(Vex_number[6]); pictureBox6.Visible = true; }
            if (comboBox1.Text == "1栋宿舍") { display(Vex_number[7]); pictureBox7.Visible = true; }
            if (comboBox1.Text == "一饭（2栋宿舍）") { display(Vex_number[8]); pictureBox8.Visible = true; }
            if (comboBox1.Text == "3栋宿舍") { display(Vex_number[9]); pictureBox9.Visible = true; }
            if (comboBox1.Text == "康大超市") { display(Vex_number[10]); pictureBox10.Visible = true; }
            if (comboBox1.Text == "9-12栋宿舍") { display(Vex_number[11]); pictureBox11.Visible = true; }
            if (comboBox1.Text == "13-16栋宿舍") { display(Vex_number[12]); pictureBox12.Visible = true; }
            if (comboBox1.Text == "二饭（17-18栋宿舍）") { display(Vex_number[13]); pictureBox13.Visible = true; }
            if (comboBox1.Text == "第一行政楼") { display(Vex_number[14]); pictureBox14.Visible = true; }
            if (comboBox1.Text == "金穗饭堂") { display(Vex_number[15]); pictureBox15.Visible = true; }
            if (comboBox1.Text == "小东湖") { display(Vex_number[16]); pictureBox16.Visible = true; }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            box = 2;
            pictureInitialize(2);
            if (comboBox2.Text == "学校正门") { display(Vex_number[1]); pictureBox17.Visible = true; }
            if (comboBox2.Text == "图书馆") { display(Vex_number[2]); pictureBox18.Visible = true; }
            if (comboBox2.Text == "教学楼") { display(Vex_number[3]); pictureBox19.Visible = true; }
            if (comboBox2.Text == "第二行政楼") { display(Vex_number[4]); pictureBox20.Visible = true; }
            if (comboBox2.Text == "田径场") { display(Vex_number[5]); pictureBox21.Visible = true; }
            if (comboBox2.Text == "篮球场") { display(Vex_number[6]); pictureBox22.Visible = true; }
            if (comboBox2.Text == "1栋宿舍") { display(Vex_number[7]); pictureBox23.Visible = true; }
            if (comboBox2.Text == "一饭（2栋宿舍）") { display(Vex_number[8]); pictureBox24.Visible = true; }
            if (comboBox2.Text == "3栋宿舍") { display(Vex_number[9]); pictureBox25.Visible = true; }
            if (comboBox2.Text == "康大超市") { display(Vex_number[10]); pictureBox26.Visible = true; }
            if (comboBox2.Text == "9-12栋宿舍") { display(Vex_number[11]); pictureBox27.Visible = true; }
            if (comboBox2.Text == "13-16栋宿舍") { display(Vex_number[12]); pictureBox28.Visible = true; }
            if (comboBox2.Text == "二饭（17-18栋宿舍）") { display(Vex_number[13]); pictureBox29.Visible = true; }
            if (comboBox2.Text == "第一行政楼") { display(Vex_number[14]); pictureBox30.Visible = true; }
            if (comboBox2.Text == "金穗饭堂") { display(Vex_number[15]); pictureBox31.Visible = true; }
            if (comboBox2.Text == "小东湖") { display(Vex_number[16]); pictureBox32.Visible = true; }
        }

        private void display(int x)
        {
            int i = 1;
            for (i = 1; i < N; i++)
                if (i == x)
                    if (box == 1)
                    { textBox1.Text = Vex_info[i]; }
                    else if (box == 2)
                    { textBox2.Text = Vex_info[i]; }
        }
        //选框内容进行函数调用，分别为显示信息，在地图上画点标注地理位置//
        private void Floyd()
        {
            distance = 0;
            Arc_Legth[1, 2] = Arc_Legth[2, 1] = 50;
            Arc_Legth[1, 10] = Arc_Legth[10, 1] = 100;
            Arc_Legth[2, 3] = Arc_Legth[3, 2] = 130;
            Arc_Legth[2, 7] = Arc_Legth[7, 2] = 210;
            Arc_Legth[2, 8] = Arc_Legth[8, 2] = 160;
            Arc_Legth[3, 4] = Arc_Legth[4, 3] = 200;
            Arc_Legth[3, 5] = Arc_Legth[5, 3] = 100;
            Arc_Legth[3, 7] = Arc_Legth[7, 3] = 220;
            Arc_Legth[3, 8] = Arc_Legth[8, 3] = 170;
            Arc_Legth[3, 9] = Arc_Legth[9, 3] = 100;
            Arc_Legth[4, 6] = Arc_Legth[6, 4] = 90;
            Arc_Legth[4, 16] = Arc_Legth[16, 4] = 100;
            Arc_Legth[4, 9] = Arc_Legth[9, 4] = 150;
            Arc_Legth[4, 16] = Arc_Legth[16, 4] = 70;
            Arc_Legth[5, 6] = Arc_Legth[6, 5] = 30;
            Arc_Legth[5, 8] = Arc_Legth[8, 5] = 90;
            Arc_Legth[6, 16] = Arc_Legth[16, 6] = 50;
            Arc_Legth[7, 8] = Arc_Legth[8, 7] = 80;
            Arc_Legth[9, 10] = Arc_Legth[10, 9] = 90;
            Arc_Legth[9, 11] = Arc_Legth[11, 9] = 140;
            Arc_Legth[10, 11] = Arc_Legth[11, 10] = 75;
            Arc_Legth[11, 12] = Arc_Legth[12, 11] = 90;
            Arc_Legth[12, 13] = Arc_Legth[13, 12] = 50;
            Arc_Legth[12, 14] = Arc_Legth[14, 12] = 80;
            Arc_Legth[13, 15] = Arc_Legth[15, 13] = 105;
            Arc_Legth[14, 15] = Arc_Legth[15, 14] = 120;
            Arc_Legth[15, 16] = Arc_Legth[16, 15] = 50;
            for (int c = 1; c < N; c++)
                for (int d = 1; d < N; d++)
                    if (Arc_Legth[c, d] == 0 && c != d)
                        Arc_Legth[c, d] = MAX;
            for (int v = 1; v < N; v++)
                for (int w = 1; w < N; w++)
                {
                    for (int u = 0; u < N; u++)
                        P[v, w, u] = false;
                    if (Arc_Legth[v, w] < MAX)
                    {
                        P[v, w, v] = true;
                        P[v, w, w] = true;
                    }
                }
            for (int v = 1; v < N; v++)
                for (int w = 1; w < N; w++)
                    for (int u = 1; u < N; u++)
                        if (Arc_Legth[v, u] + Arc_Legth[u, w] < Arc_Legth[v, w])
                        {
                            Arc_Legth[v, w] = Arc_Legth[v, u] + Arc_Legth[u, w];
                            new_vexnum[v, w] = new_vexnum[v, u] + u + "/" + new_vexnum[u, w];
                            for (int i = 1; i < N; i++)
                                P[v, w, i] = P[v, u, i] || P[u, w, i];
                        }
        }
        //求出最短加权路径以及路线顺序,佛洛依德算法//
        private void showroad()
        {
            //Floyd();
            int n = 0, k = 0;
            int p = 0, q = 0;
            for (int m = 1; m < N; m++)
            {
                if (comboBox1.Text == Vex_sight[m])
                    n = m;
                if (comboBox2.Text == Vex_sight[m])
                    k = m;
            }
            textBox4.Text = Vex_sight[n];
            textBox4.Text += "→";
            if (new_vexnum[n, k] != null)
            {
                string[] new_path = new_vexnum[n, k].Split('/');
                int[] connect = new int[new_path.Length + 1];
                connect[0] = n; connect[new_path.Length] = k;
                for (int i = 1; i < new_path.Length; i++)
                {
                    connect[i] = Convert.ToInt16(new_path[i - 1]);
                }
                for (int i = 0; i < new_path.Length; i++)
                {
                    distance += Arc_Legth[connect[i], connect[i + 1]];
                }
                for (int i = 0; i < new_path.Length - 1; i++)
                {
                    p = Convert.ToInt16(new_path[i]);
                    if (i == 0)
                        if (i + 1 < new_path.Length - 1 && i != 0)
                        {
                            p = Convert.ToInt16(new_path[i]);
                        }
                    textBox4.Text += Vex_sight[p];
                    textBox4.Text += "→";
                }
            }
            if (new_vexnum[n, k] == null)
            {
                q = n;
            }
            distance += Arc_Legth[q, k];
            textBox4.Text += Vex_sight[k];
            textBox3.Text = Convert.ToString(distance);
        }
        //显示路线//
        private void buttonCalc_Click(object sender, EventArgs e)
        {
            Floyd();
            showroad();
        }
        //点击按钮触发事件//
        private void 复位toolStripButton_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
            comboBox2.Text = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            pictureInitialize(1);
            pictureInitialize(2);
        }

        private void 退出toolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void 帮助toolStripButton_Click(object sender, EventArgs e)
        {
            help he = new help();
            he.Show();
        }

        private void 关于toolStripButton_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        private void 访问toolStripLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("IEXPLORE.EXE", "http://2011.scnuzc.cn");
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox33.Visible = true;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox33.Visible = false;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox34.Visible = true;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox34.Visible = false;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox35.Visible = true;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox35.Visible = false;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox36.Visible = true;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox36.Visible = false;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox37.Visible = true;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox37.Visible = false;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox38.Visible = true;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox38.Visible = false;
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox39.Visible = true;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox39.Visible = false;
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox40.Visible = true;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox40.Visible = false;
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox41.Visible = true;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox41.Visible = false;
        }

        private void label13_MouseEnter(object sender, EventArgs e)
        {
            pictureBox42.Visible = true;
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox42.Visible = false;
        }

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox43.Visible = true;
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox43.Visible = false;
        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            pictureBox44.Visible = true;
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            pictureBox44.Visible = false;
        }

        private void label16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox45.Visible = true;
        }

        private void label16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox45.Visible = false;
        }

        private void label17_MouseEnter(object sender, EventArgs e)
        {
            pictureBox46.Visible = true;
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            pictureBox46.Visible = false;
        }

        private void label18_MouseEnter(object sender, EventArgs e)
        {
            pictureBox47.Visible = true;
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            pictureBox47.Visible = false;
        }

        private void label19_MouseEnter(object sender, EventArgs e)
        {
            pictureBox48.Visible = true;
        }

        private void label19_MouseLeave(object sender, EventArgs e)
        {
            pictureBox48.Visible = false;
        }

    }
}