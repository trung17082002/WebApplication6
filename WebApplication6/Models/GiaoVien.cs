namespace WebApplication6.Models
{
    public class GiaoVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        public GiaoVien() { }

        public GiaoVien(int id, string hoTen, string ngaySinh, string diaChi, string soDienThoai, string email)
        {
            Id = id;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
        }
    }
}
