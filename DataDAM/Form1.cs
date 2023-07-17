using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataDAM
{
    public partial class allForm : Form
    {
        private string[] imageFiles;  // 이미지 파일 경로들을 저장할 배열
        private int currentIndex;  // 현재 이미지의 인덱스
        private Timer timer;  // 타이머 객체
        private int count;
        private string currentFileName;

        public allForm()
        {
            InitializeComponent();

        }

        private void allForm_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1000;  // 1초마다 이미지 전환
            timer.Tick += Timer_Tick;
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            string folderPath = @"D:\UDP\image";  // 실제 이미지가 있는 폴더 경로로 수정해주세요
            imageFiles = System.IO.Directory.GetFiles(folderPath, "*.jpg");

            Array.Sort(imageFiles, (a, b) =>
            {
                string fileNameA = System.IO.Path.GetFileNameWithoutExtension(a);
                string fileNameB = System.IO.Path.GetFileNameWithoutExtension(b);

                // 파일명에서 숫자 부분만 추출하여 비교
                int numberA = int.Parse(System.Text.RegularExpressions.Regex.Match(fileNameA, @"\d+").Value);
                int numberB = int.Parse(System.Text.RegularExpressions.Regex.Match(fileNameB, @"\d+").Value);

                return numberA.CompareTo(numberB);
            });

            currentIndex = 0;
            count = 1;
            UpdateLabel1();  // Label1 업데이트

            if (imageFiles.Length > 0)
            {
                pictureBox1.Load(imageFiles[currentIndex]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                currentFileName = System.IO.Path.GetFileName(imageFiles[currentIndex]);
                label2.Text = currentFileName;  // label2에 현재 파일명 설정
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (imageFiles == null || imageFiles.Length == 0)
                return;

            timer.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= imageFiles.Length)
            {
                currentIndex = 0;  // 마지막 이미지일 경우, 처음 이미지로 돌아감
            }
            pictureBox1.Load(imageFiles[currentIndex]);

            count++;  // 카운트 값 증가
            UpdateLabel1();  // Label1 업데이트

            currentFileName = System.IO.Path.GetFileName(imageFiles[currentIndex]);
            label2.Text = currentFileName;  // label2에 현재 파일명 업데이트
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void UpdateLabel1()
        {
            label1.Text = $"Count: {count}";  // Label1 업데이트
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
