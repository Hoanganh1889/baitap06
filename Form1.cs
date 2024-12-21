using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace BaiTap6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Model1 context = new Model1();
            List<Khoa> listKhoa = context.Khoa.ToList();
            List<SinhVien> listSinhVien = context.SinhVien.ToList();
            BindGrid(listSinhVien);
            FillFalcultyCombobox(listSinhVien);
        }
        private void FillFalcultyCombobox(List<SinhVien> listStudent)
        {
            this.cmbFaculty.DataSource = listStudent;
            this.cmbFaculty.DisplayMember = "tenKhoa";
            this.cmbFaculty.ValueMember = "maKhoa";
        }

        private void BindGrid(List<SinhVien> listStudent)
        {
            dgvSinhVien.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvSinhVien.Rows.Add();
                dgvSinhVien.Rows[index].Cells[0].Value = item.maSV;
                dgvSinhVien.Rows[index].Cells[1].Value = item.hoTen;
                dgvSinhVien.Rows[index].Cells[2].Value = item.maKhoa;
                dgvSinhVien.Rows[index].Cells[3].Value = item.diemTB;
            }
       }
     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                string maSV = txtMaSV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                int maKhoa = int.Parse(cmbFaculty.Text.Trim());
                float diemTB = float.Parse(txtDiemTB.Text.Trim());

                // Tạo đối tượng SinhVien mới
                SinhVien newStudent = new SinhVien()
                {
                    maSV = maSV,
                    hoTen = hoTen,
                    maKhoa=maKhoa,
                    diemTB = diemTB
                };

                // Thêm vào CSDL
                using (Model1 context = new Model1())
                {
                    context.SinhVien.Add(newStudent);
                    context.SaveChanges();
                }
                // Load lại dữ liệu
                LoadData();
                MessageBox.Show("Thêm sinh viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                string maSV = txtMaSV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                int maKhoa = int.Parse(cmbFaculty.Text.Trim());
                float diemTB = float.Parse(txtDiemTB.Text.Trim());

                // Sửa thông tin sinh viên trong CSDL
                using (Model1 context = new Model1())
                {
                    SinhVien student = context.SinhVien.FirstOrDefault(sv => sv.maSV == maSV);
                    if (student != null)
                    {
                        student.hoTen = hoTen;
                        student.diemTB = diemTB;
                        context.SaveChanges();

                        // Load lại dữ liệu
                        LoadData();
                        MessageBox.Show("Sửa thông tin sinh viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để sửa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sinh viên: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã sinh viên từ TextBox
                string maSV = txtMaSV.Text.Trim();

                // Xóa sinh viên khỏi CSDL
                using (Model1 context = new Model1())
                {
                    SinhVien student = context.SinhVien.FirstOrDefault(sv => sv.maSV == maSV);
                    if (student != null)
                    {
                        context.SinhVien.Remove(student);
                        context.SaveChanges();

                        // Load lại dữ liệu
                        LoadData();
                        MessageBox.Show("Xóa sinh viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message);
            }
        }
        private void LoadData()
        {
            using (Model1 context = new Model1())
            {
                List<SinhVien> listSinhVien = context.SinhVien.Include("Khoa").ToList();
                BindGrid(listSinhVien);
            }
        }
    }
}
