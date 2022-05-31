namespace WinFormsApp1Pong
{
    public partial class Form1 : Form
    {
   
        private int xPosition = 0;
        private int yPosition = 0;
        private int PxPh = 100;
        private int PyPh = 500;
        private int incdecx = 5;
        private int incdecy = 20;
        private int movpacd = 1;
        private int FrameNum = 0;

        bool goleft;
        bool goright;
        int ballx = 5;
        int bally = 5;
        int Score = 000000;
        int speed = 1;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {

            Moveball();
            label2.Text = Score.ToString();

            if (Ball.Bounds.IntersectsWith(Paddle.Bounds))
             {
                incdecy = -incdecy;
                Score = Score + 200;

            }

            if (goleft==true && Paddle.Left>97 )
            {
                
                Paddle.Left -= 20;
            }
            if (goright == true && Paddle.Left < 295)
            {
                
                Paddle.Left += 20;
            }
        }
        void Moveball()
        {
            
            if (PxPh > 267)
                incdecx = -5 ;
            if (PxPh < -57)
                incdecx = 5;
            PxPh += incdecx;
            Ball.Left += incdecx;
            

            if (PyPh > 570)
                incdecy = 0 ;

            
            
            

                //incdecx = 0;
            if (PyPh < 20)
                incdecy = -incdecy + 0;
            PyPh += incdecy;
            Ball.Top += incdecy;
        }

        void Gameover()
        {
            string mensaje = "GameOver Intentar denuevo?";
            string caption = "Gameover";
            MessageBoxButtons botones = MessageBoxButtons.YesNo;


            MessageBoxIcon icons = MessageBoxIcon.None;
           
            DialogResult resultado;
            resultado = MessageBox.Show(mensaje, caption, botones, icons);

            if (resultado == DialogResult.Yes)
            {
                Score = 0;
                speed = 1;
                incdecy = 20;
                timer2.Enabled = true;
            }
            if (resultado == DialogResult.No)
            {
                this.Close();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();

        }
       
    
        
       
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;

            }
            
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright= false;
            }


        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            goleft = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            goleft = true;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            goright = true;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            goright = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            

            incdecy = incdecy + 5;

            speed++;
            label4.Text = speed.ToString();
            timer3.Enabled = true;
            timer2.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer3.Enabled = false;

        }
    }
}