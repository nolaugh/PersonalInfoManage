using PersonalInfoManage.SqlLiteClass;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalInfoManage
{
    public partial class Form_Main : Form
    {
        public static byte[] imgBytesIn;
        DataClass dataClass = new DataClass();
        public static string projectDirectory = Directory.GetCurrentDirectory();

        public string photoDirectory = Path.Combine(projectDirectory, "Photo");
        public int currentImageIndex = 0;
        public int totalImages = 0;

        public string zpphotoDirectory = Path.Combine(projectDirectory, "zpPhoto");
        public int zpcurrentImageIndex = 0;
        public int zptotalImages = 0;

        public static string AllSql = "select ID,Time as 记事时间,Topic as 记事主题,Things as 记事内容 from tb_Day";
        public static DataSet MyDS_Grid;

        public static string ClassAllSql = "select ID,ClassName as 课程名称,ClassScore as 课程学分,ClassResult as 课程成绩,ClassLevel as 合格等级 from tb_Class";
        public static DataSet ClassMyDS_Grid;

        public static string MoneyAllSql = "select ID,Kind as 收支类型,Money as 收支金额 from tb_Money";
        public static DataSet MoneyMyDS_Grid;

        public string DayID = "";
        public string ClassID = "";
        public string MoneyID = "";

       

        public Form_Main()
        {
            InitializeComponent();

            uiWaitingBar1.Visible = false;
            uiWaitingBar2.Visible = false;
            uiWaitingBar3.Visible = false;
            uiWaitingBar4.Visible = false;
            uiWaitingBar5.Visible = false;
            uiWaitingBar6.Visible = false;

            try
            {
                SQLiteDataReader reader = dataClass.selectData("Select * from tb_SelfInfo where ID='1'");
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        string updatedName = reader["Name"].ToString();
                        txt_Name.Text = updatedName;

                        string updatedJob = reader["Job"].ToString();
                        txt_Job.Text = updatedJob;

                        string updatedPhone = reader["Phone"].ToString();
                        txt_Phone.Text = updatedPhone;

                        string updatedMail = reader["Mail"].ToString();
                        txt_Mail.Text = updatedMail;

                        string updatedPublish = reader["Publish"].ToString();
                        txt_Publish.Text = updatedPublish;

                        string updatedSchool = reader["School"].ToString();
                        txt_School.Text = updatedSchool;

                        string updatedPrice = reader["Price"].ToString();
                        txt_Price.Text = updatedPrice;

                        string updatedSkill = reader["Skill"].ToString();
                        txt_Skill.Text = updatedSkill;

                        pic_Self.Image = dataClass.GetImage();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("1" + ex);
            }

            // 获取相册目录中的所有图片文件
            string[] imageFiles = Directory.GetFiles(photoDirectory, "*.jpg"); // 这里假设图片格式为 jpg，可以根据实际情况更改

            totalImages = imageFiles.Length;
             currentImageIndex = 0;
            if (totalImages > 0 && currentImageIndex >= 0 && currentImageIndex < totalImages)
            {
                string currentImagePath = imageFiles[currentImageIndex];
                pic_Show.Image = System.Drawing.Image.FromFile(currentImagePath);
            }
            lbl_number.Text = currentImageIndex+1 + "/" + totalImages;

            // 获取相册目录中的所有图片文件
            string[] zpimageFiles = Directory.GetFiles(zpphotoDirectory, "*.jpg"); // 这里假设图片格式为 jpg，可以根据实际情况更改

            zptotalImages = zpimageFiles.Length;
            zpcurrentImageIndex = 0;
            if (zptotalImages > 0 && zpcurrentImageIndex >= 0 && zpcurrentImageIndex < zptotalImages)
            {
                string currentImagePath = zpimageFiles[zpcurrentImageIndex];
                pic_zp.Image = System.Drawing.Image.FromFile(currentImagePath);
            }
            lbl_zpNumber.Text = zpcurrentImageIndex + 1 + "/" + zptotalImages;

            dgv_Day.RowHeadersVisible = false;
            dgv_Day.AllowUserToAddRows = false;
            MyDS_Grid = dataClass.getDataSet(AllSql, "tb_Day");
            dgv_Day.DataSource = MyDS_Grid.Tables[0];
            dgv_Day.Columns[1].Width = 80;
            dgv_Day.Columns[2].Width =80;
            dgv_Day.Columns[3].Width = 135;
            dgv_Day.Columns[0].Visible = false;

            dgv_Class.RowHeadersVisible = false;
            dgv_Class.AllowUserToAddRows = false;
            ClassMyDS_Grid = dataClass.getDataSet(ClassAllSql, "tb_Class");
            dgv_Class.DataSource = ClassMyDS_Grid.Tables[0];
            dgv_Class.Columns[0].Visible = false;
            dgv_Class.Columns[1].Width = 135;
            dgv_Class.Columns[2].Width = 135;
            dgv_Class.Columns[3].Width = 135;
            dgv_Class.Columns[4].Width = 135;

            dgv_Money.RowHeadersVisible = false;
            dgv_Money.AllowUserToAddRows = false;
            MoneyMyDS_Grid = dataClass.getDataSet(MoneyAllSql, "tb_Money");
            dgv_Money.DataSource = MoneyMyDS_Grid.Tables[0];
            dgv_Money.Columns[0].Visible = false;
            dgv_Money.Columns[1].Width = 280;
            dgv_Money.Columns[2].Width = 280;


            int columnIndex = 2; // 列索引
            int sum = 0;

            foreach (DataGridViewRow row in dgv_Money.Rows)
            {
                // 检查单元格的值是否可以转换为整数
                if (int.TryParse(row.Cells[columnIndex].Value?.ToString(), out int cellValue))
                {
                    sum += cellValue;
                }
            }
            txt_Money.Text= sum.ToString();
        }

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            ofd_pic.Filter = "*.jpg|*.jpg";   //指定OpenFileDialog控件打开的文件格式
            if (ofd_pic.ShowDialog(this) == DialogResult.OK)  //如果打开了图片文件
            {
                try
                {
                    pic_Self.Image = System.Drawing.Image.FromFile(ofd_pic.FileName);  //将图片文件存入到PictureBox控件中
                    string strimg = ofd_pic.FileName.ToString();  //记录图片的所在路径
                    FileStream fs = new FileStream(strimg, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
                    BinaryReader br = new BinaryReader(fs);
                    imgBytesIn = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pic_Self.Image = null;
                }
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            pic_Self.Image=null;
            imgBytesIn = new byte[65536];
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            uiWaitingBar1.Visible = true;
            try
            {
                dataClass.UpdateImage(imgBytesIn);

                // 重新查询数据
                SQLiteDataReader reader = dataClass.selectData("Select * from tb_SelfInfo where ID='1'");
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        string updatedName = reader["Name"].ToString();
                        txt_Name.Text = updatedName;

                        string updatedJob = reader["Job"].ToString();
                        txt_Job.Text = updatedJob;

                        string updatedPhone = reader["Phone"].ToString();
                        txt_Phone.Text = updatedPhone;

                        string updatedMail = reader["Mail"].ToString();
                        txt_Mail.Text = updatedMail;

                        string updatedPublish = reader["Publish"].ToString();
                        txt_Publish.Text = updatedPublish;

                        string updatedSchool = reader["School"].ToString();
                        txt_School.Text = updatedSchool;

                        string updatedPrice = reader["Price"].ToString();
                        txt_Price.Text = updatedPrice;

                        string updatedSkill = reader["Skill"].ToString();
                        txt_Skill.Text = updatedSkill;

                        pic_Self.Image = dataClass.GetImage();
                    }

                    reader.Close();
                    MessageBox.Show("读取成功！", "提示");
                    uiWaitingBar1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar1.Visible = false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            uiWaitingBar1.Visible = true;
            try
            {
                string Name = txt_Name.Text.ToString().Trim();
                string Job = txt_Job.Text.ToString().Trim();
                string Phone = txt_Phone.Text.ToString().Trim();
                string Mail = txt_Mail.Text.ToString().Trim();
                string Publish = txt_Publish.Text.ToString().Trim();
                string School = txt_School.Text.ToString().Trim();
                string Price = txt_Price.Text.ToString().Trim();
                string Skill = txt_Skill.Text.ToString().Trim();

                dataClass.getsqlcom("update tb_SelfInfo set Name='" + Name + "' where ID=1");
                dataClass.getsqlcom("update tb_SelfInfo set Job='" + Job + "' where ID=1");
                dataClass.getsqlcom("update tb_SelfInfo set Phone='" + Phone + "' where ID=1");
                dataClass.getsqlcom("update tb_SelfInfo set Mail='" + Mail + "' where ID=1");
                dataClass.getsqlcom("update tb_SelfInfo set Publish='" + Publish + "' where ID=1");
                dataClass.getsqlcom("update tb_SelfInfo set School='" + School + "' where ID=1");
                dataClass.getsqlcom("update tb_SelfInfo set Price='" + Price + "' where ID=1");
                dataClass.getsqlcom("update tb_SelfInfo set Skill='" + Skill + "' where ID=1");
                dataClass.UpdateImage(imgBytesIn);

                // 重新查询数据
                SQLiteDataReader reader = dataClass.selectData("Select * from tb_SelfInfo where ID='1'");
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        string updatedName = reader["Name"].ToString();
                        txt_Name.Text = updatedName;

                        string updatedJob = reader["Job"].ToString();
                        txt_Job.Text = updatedJob;

                        string updatedPhone = reader["Phone"].ToString();
                        txt_Phone.Text = updatedPhone;

                        string updatedMail = reader["Mail"].ToString();
                        txt_Mail.Text = updatedMail;

                        string updatedPublish = reader["Publish"].ToString();
                        txt_Publish.Text = updatedPublish;

                        string updatedSchool = reader["School"].ToString();
                        txt_School.Text = updatedSchool;

                        string updatedPrice = reader["Price"].ToString();
                        txt_Price.Text = updatedPrice;

                        string updatedSkill = reader["Skill"].ToString();
                        txt_Skill.Text = updatedSkill;

                        pic_Self.Image = dataClass.GetImage();
                    }

                    reader.Close();
                    MessageBox.Show("保存成功！", "提示");
                    uiWaitingBar1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！"+ex,"提示");
                uiWaitingBar1.Visible = false;
            }
        }

        private void button_Set_Click(object sender, EventArgs e)
        {
            uiWaitingBar2.Visible = true;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;";
                openFileDialog.Title = "Select Images";
                openFileDialog.Multiselect = true;
                string[] imageFiles = Directory.GetFiles(photoDirectory, "*.jpg");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        // 构建目标路径，将文件复制到图片文件夹中
                        string targetPath = Path.Combine(photoDirectory, Path.GetFileName(filePath));
                        File.Copy(filePath, targetPath, true);

                        // 更新图片列表
                        imageFiles = Directory.GetFiles(photoDirectory, "*.jpg");

                        // 更新总图片数量
                        totalImages = imageFiles.Length;

                        // 切换到新添加的图片
                        currentImageIndex = totalImages - 1;
                        if (totalImages > 0 && currentImageIndex >= 0 && currentImageIndex < totalImages)
                        {
                            string currentImagePath = imageFiles[currentImageIndex];
                            pic_Show.Image = System.Drawing.Image.FromFile(currentImagePath);
                        }
                        lbl_number.Text = currentImageIndex + 1 + "/" + totalImages;

                        uiWaitingBar2.Visible = false;
                    }
                }
            }
        }

        private void btn_Prv_Click(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex - 1 + totalImages) % totalImages;
            string[] imageFiles = Directory.GetFiles(photoDirectory, "*.jpg");
            if (totalImages > 0 && currentImageIndex >= 0 && currentImageIndex < totalImages)
            {
                string currentImagePath = imageFiles[currentImageIndex];
                pic_Show.Image = System.Drawing.Image.FromFile(currentImagePath);
            }
            lbl_number.Text = currentImageIndex + 1 + "/" + totalImages;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1 ) % totalImages;
            string[] imageFiles = Directory.GetFiles(photoDirectory, "*.jpg");
            if (totalImages > 0 && currentImageIndex >= 0 && currentImageIndex < totalImages)
            {
                string currentImagePath = imageFiles[currentImageIndex];
                pic_Show.Image = System.Drawing.Image.FromFile(currentImagePath);
            }
            lbl_number.Text = currentImageIndex + 1 + "/" + totalImages;
        }

        private void btn_zp_Click(object sender, EventArgs e)
        {
            uiWaitingBar3.Visible = true;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;";
                openFileDialog.Title = "Select Images";
                openFileDialog.Multiselect = true;
                string[] imageFiles = Directory.GetFiles(zpphotoDirectory, "*.jpg");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        // 构建目标路径，将文件复制到图片文件夹中
                        string targetPath = Path.Combine(zpphotoDirectory, Path.GetFileName(filePath));
                        File.Copy(filePath, targetPath, true);

                        // 更新图片列表
                        imageFiles = Directory.GetFiles(zpphotoDirectory, "*.jpg");

                        // 更新总图片数量
                        zptotalImages = imageFiles.Length;

                        // 切换到新添加的图片
                        zpcurrentImageIndex = zptotalImages - 1;
                        if (zptotalImages > 0 && zpcurrentImageIndex >= 0 && zpcurrentImageIndex < zptotalImages)
                        {
                            string currentImagePath = imageFiles[currentImageIndex];
                            pic_zp.Image = System.Drawing.Image.FromFile(currentImagePath);
                        }
                        lbl_zpNumber.Text = zpcurrentImageIndex + 1 + "/" + zptotalImages;

                        uiWaitingBar3.Visible = false;
                    }
                }
            }
        }

        private void btn_zpPrv_Click(object sender, EventArgs e)
        {
            zpcurrentImageIndex = (zpcurrentImageIndex - 1 + zptotalImages) % zptotalImages;
            string[] imageFiles = Directory.GetFiles(zpphotoDirectory, "*.jpg");
            if (zptotalImages > 0 && zpcurrentImageIndex >= 0 && zpcurrentImageIndex < zptotalImages)
            {
                string currentImagePath = imageFiles[zpcurrentImageIndex];
                pic_zp.Image = System.Drawing.Image.FromFile(currentImagePath);
            }
            lbl_zpNumber.Text = zpcurrentImageIndex + 1 + "/" + zptotalImages;
        }

        private void btn_zpNext_Click(object sender, EventArgs e)
        {
            zpcurrentImageIndex = (zpcurrentImageIndex + 1 ) % zptotalImages;
            string[] imageFiles = Directory.GetFiles(zpphotoDirectory, "*.jpg");
            if (zptotalImages > 0 && zpcurrentImageIndex >= 0 && zpcurrentImageIndex < zptotalImages)
            {
                string currentImagePath = imageFiles[zpcurrentImageIndex];
                pic_zp.Image = System.Drawing.Image.FromFile(currentImagePath);
            }
            lbl_zpNumber.Text = zpcurrentImageIndex + 1 + "/" + zptotalImages;
        }

        private void btn_daySave_Click(object sender, EventArgs e)
        {
            uiWaitingBar4.Visible = true;
            try
            {
                string Time = txt_Time.Text.ToString().Trim();
                string Topic = txt_topic.Text.ToString().Trim();
                string Things = txt_Things.Text.ToString().Trim();

                dataClass.getsqlcom("update tb_Day set Time='" + Time + "' where ID='"+DayID+"'");
                dataClass.getsqlcom("update tb_Day set Topic='" + Topic + "' where ID='" + DayID + "'");
                dataClass.getsqlcom("update tb_Day set Things='" + Things + "' where ID='" + DayID + "'");

                MyDS_Grid = dataClass.getDataSet(AllSql, "tb_Day");
                dgv_Day.DataSource = MyDS_Grid.Tables[0];

                MessageBox.Show("保存成功！", "提示");
                uiWaitingBar4.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar4.Visible = false;
            }
        }

        private void btn_DayNew_Click(object sender, EventArgs e)
        {
            uiWaitingBar4.Visible = true;
            try
            {
                string Time = txt_Time.Text.ToString().Trim();
                string Topic = txt_topic.Text.ToString().Trim();
                string Things = txt_Things.Text.ToString().Trim();
                dataClass.getsqlcom("INSERT INTO tb_Day (Time, Topic, Things) VALUES ('" + Time + "','" + Topic + "','" + Things + "')");
                MyDS_Grid = dataClass.getDataSet(AllSql, "tb_Day");
                dgv_Day.DataSource = MyDS_Grid.Tables[0];
                MessageBox.Show("新增成功！", "提示");
                uiWaitingBar4.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar4.Visible = false;
            }
        }

        private void btn_dayDelete_Click(object sender, EventArgs e)
        {
            uiWaitingBar4.Visible = true;
            try
            {
                string Time = txt_Time.Text.ToString().Trim();
                string Topic = txt_topic.Text.ToString().Trim();
                string Things = txt_Things.Text.ToString().Trim();
                dataClass.getsqlcom("DELETE FROM tb_Day WHERE ID ='"+DayID+"'");
                MyDS_Grid = dataClass.getDataSet(AllSql, "tb_Day");
                dgv_Day.DataSource = MyDS_Grid.Tables[0];
                MessageBox.Show("删除成功！", "提示");
                uiWaitingBar4.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar4.Visible = false;
            }
        }

        private void dgv_Day_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Day.RowCount > 0)
            {
                try
                {
                    DayID= dgv_Day[0, dgv_Day.CurrentCell.RowIndex].Value.ToString();
                    txt_Time.Text = dgv_Day[1, dgv_Day.CurrentCell.RowIndex].Value.ToString();
                    txt_topic.Text = dgv_Day[2, dgv_Day.CurrentCell.RowIndex].Value.ToString();
                    txt_Things.Text = dgv_Day[3, dgv_Day.CurrentCell.RowIndex].Value.ToString();
                }
                catch
                {
                    txt_Time.Text = "";
                    txt_topic.Text = "";
                    txt_Things.Text = "";
                }
            }
        }

        private void btn_NewClass_Click(object sender, EventArgs e)
        {
            uiWaitingBar5.Visible = true;
            try
            {
                string ClassName = txt_ClassName.Text.ToString().Trim();
                string ClassScore = txt_ClassScore.Text.ToString().Trim();
                string ClassResult = txt_ClassResult.Text.ToString().Trim();
                string ClassLevel = txt_ClassLevel.Text.ToString().Trim();
                dataClass.getsqlcom("INSERT INTO tb_Class (ClassName, ClassScore, ClassResult,ClassLevel) " +
                    "VALUES ('" + ClassName + "','" + ClassScore + "','" + ClassResult + "','"+ ClassLevel + "')");

                ClassMyDS_Grid = dataClass.getDataSet(ClassAllSql, "tb_Class");
                dgv_Class.DataSource = ClassMyDS_Grid.Tables[0];

                MessageBox.Show("新增成功！", "提示");
                uiWaitingBar5.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar5.Visible = false;
            }
        }

        private void btn_SaveClass_Click(object sender, EventArgs e)
        {
            uiWaitingBar5.Visible = true;
            try
            {
                string ClassName = txt_ClassName.Text.ToString().Trim();
                string ClassScore = txt_ClassScore.Text.ToString().Trim();
                string ClassResult = txt_ClassResult.Text.ToString().Trim();
                string ClassLevel = txt_ClassLevel.Text.ToString().Trim();

                dataClass.getsqlcom("update tb_Class set ClassName='" + ClassName + "' where ID='" + ClassID + "'");
                dataClass.getsqlcom("update tb_Class set ClassScore='" + ClassScore + "' where ID='" + ClassID + "'");
                dataClass.getsqlcom("update tb_Class set ClassResult='" + ClassResult + "' where ID='" + ClassID + "'");
                dataClass.getsqlcom("update tb_Class set ClassLevel='" + ClassLevel + "' where ID='" + ClassID + "'");

                ClassMyDS_Grid = dataClass.getDataSet(ClassAllSql, "tb_Class");
                dgv_Class.DataSource = ClassMyDS_Grid.Tables[0];

                MessageBox.Show("保存成功！", "提示");
                uiWaitingBar5.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar5.Visible = false;
            }
        }

        private void btn_DeleteClass_Click(object sender, EventArgs e)
        {
            uiWaitingBar5.Visible = true;
            try
            {
                dataClass.getsqlcom("DELETE FROM tb_Class WHERE ID ='" + ClassID + "'");
                ClassMyDS_Grid = dataClass.getDataSet(ClassAllSql, "tb_Class");
                dgv_Class.DataSource = ClassMyDS_Grid.Tables[0];
                MessageBox.Show("删除成功！", "提示");
                uiWaitingBar5.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar5.Visible = false;
            }
        }

        private void btn_Calc_Click(object sender, EventArgs e)
        {
            int columnIndex = 3; // 列索引
            int sum = 0;

            foreach (DataGridViewRow row in dgv_Class.Rows)
            {
                // 检查单元格的值是否可以转换为整数
                if (int.TryParse(row.Cells[columnIndex].Value?.ToString(), out int cellValue))
                {
                    sum += cellValue;
                }
            }

            // 进行运算
            double result = (double)sum / 10;
            txt_AllScore.Text = result.ToString();
            if (result < 30)
            {
                txt_PriceLevel.Text = "未获奖";
            }
            if (result > 30)
            {
                txt_PriceLevel.Text = "三等奖";
            }
            if (result > 40)
            {
                txt_PriceLevel.Text = "二等奖";
            }
            if (result > 55)
            {
                txt_PriceLevel.Text = "一等奖";
            }
   
        }

        private void dgv_Class_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Class.RowCount > 0)
            {
                try
                {
                    ClassID = dgv_Class[0, dgv_Class.CurrentCell.RowIndex].Value.ToString();
                    txt_ClassName.Text = dgv_Class[1, dgv_Class.CurrentCell.RowIndex].Value.ToString();
                    txt_ClassScore.Text = dgv_Class[2, dgv_Class.CurrentCell.RowIndex].Value.ToString();
                    txt_ClassResult.Text = dgv_Class[3, dgv_Class.CurrentCell.RowIndex].Value.ToString();
                    txt_ClassLevel.Text = dgv_Class[4, dgv_Class.CurrentCell.RowIndex].Value.ToString();
                }
                catch
                {
                    txt_ClassName.Text = "";
                    txt_ClassScore.Text = "";
                    txt_ClassResult.Text = "";
                    txt_ClassLevel.Text = "";
                }
            }
        }

        private void btn_MoneyNew_Click(object sender, EventArgs e)
        {
            uiWaitingBar6.Visible = true;
            try
            {
                string Kind = txt_Kind.Text.ToString().Trim();
                string Number = txt_MNumber.Text.ToString().Trim();
                dataClass.getsqlcom("INSERT INTO tb_Money (Kind, Money) " +
                    "VALUES ('" + Kind + "','" + Number + "')");

                MoneyMyDS_Grid = dataClass.getDataSet(MoneyAllSql, "tb_Money");
                dgv_Money.DataSource = MoneyMyDS_Grid.Tables[0];

                MessageBox.Show("新增成功！", "提示");
                uiWaitingBar6.Visible = false;
                int columnIndex = 2; // 列索引
                int sum = 0;
                foreach (DataGridViewRow row in dgv_Money.Rows)
                {
                    // 检查单元格的值是否可以转换为整数
                    if (int.TryParse(row.Cells[columnIndex].Value?.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                    }
                }
                txt_Money.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar6.Visible = false;
            }
        }

        private void btn_MoneySave_Click(object sender, EventArgs e)
        {
            uiWaitingBar6.Visible = true;
            try
            {
                string Kind = txt_Kind.Text.ToString().Trim();
                string Number = txt_MNumber.Text.ToString().Trim();
                dataClass.getsqlcom("update tb_Money set Kind='" + Kind + "' where ID='" + MoneyID + "'");
                dataClass.getsqlcom("update tb_Money set Money='" + Number + "' where ID='" + MoneyID + "'");
                MoneyMyDS_Grid = dataClass.getDataSet(MoneyAllSql, "tb_Money");
                dgv_Money.DataSource = MoneyMyDS_Grid.Tables[0];
                MessageBox.Show("保存成功！", "提示");
                uiWaitingBar6.Visible = false;
                int columnIndex = 2; // 列索引
                int sum = 0;
                foreach (DataGridViewRow row in dgv_Money.Rows)
                {
                    // 检查单元格的值是否可以转换为整数
                    if (int.TryParse(row.Cells[columnIndex].Value?.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                    }
                }
                txt_Money.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar6.Visible = false;
            }
        }

        private void btn_MoneyDelete_Click(object sender, EventArgs e)
        {
            uiWaitingBar6.Visible = true;
            try
            {
                dataClass.getsqlcom("DELETE FROM tb_Money WHERE ID ='" + MoneyID + "'");
                MoneyMyDS_Grid = dataClass.getDataSet(MoneyAllSql, "tb_Money");
                dgv_Money.DataSource = MoneyMyDS_Grid.Tables[0];
                MessageBox.Show("删除成功！", "提示");
                uiWaitingBar6.Visible = false;
                int columnIndex = 2; // 列索引
                int sum = 0;
                foreach (DataGridViewRow row in dgv_Money.Rows)
                {
                    // 检查单元格的值是否可以转换为整数
                    if (int.TryParse(row.Cells[columnIndex].Value?.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                    }
                }
                txt_Money.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查填入信息是否有误！" + ex, "提示");
                uiWaitingBar6.Visible = false;
            }
        }

        private void dgv_Money_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Money.RowCount >0)
            {
                try
                {
                    MoneyID = dgv_Money[0, dgv_Money.CurrentCell.RowIndex].Value.ToString();
                    txt_Kind.Text = dgv_Money[1, dgv_Money.CurrentCell.RowIndex].Value.ToString();
                    txt_MNumber.Text = dgv_Money[2, dgv_Money.CurrentCell.RowIndex].Value.ToString();                   
                }
                catch
                {
                    txt_Kind.Text = "";
                    txt_MNumber.Text = "";
                }
            }
        }

        private CancellationTokenSource cancellationTokenSource;

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            await Task.Run(() => Moving(cancellationTokenSource.Token));
           
        }

        private async void Moving(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // 在这里执行你的任务，例如获取当前时间
                string currentTime = DateTime.Now.ToString("HH:mm:ss");

                // 使用 Invoke 方法将 UI 更新操作切换到 UI 线程
                uiLedDisplay1.Invoke((MethodInvoker)delegate {
                    uiLedDisplay1.Text = currentTime;
                });

                uiThermometer1.Invoke((MethodInvoker)delegate {
                    Random random = new Random();
                    int fourDigitNumber = random.Next(0, 100);
                    uiThermometer1.Value = fourDigitNumber;
                });

                // 等待一段时间，可以根据需要调整
                await Task.Delay(1000); // 1秒
              
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
}
