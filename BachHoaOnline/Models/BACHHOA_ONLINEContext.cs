using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BachHoaOnline.Models
{
    public partial class BACHHOA_ONLINEContext : DbContext
    {
        public BACHHOA_ONLINEContext()
        {
        }

        public BACHHOA_ONLINEContext(DbContextOptions<BACHHOA_ONLINEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual DbSet<Chitietloai> Chitietloai { get; set; }
        public virtual DbSet<Hanghoa> Hanghoa { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Hotro> Hotro { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Loai> Loai { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcap { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Nhanxet> Nhanxet { get; set; }
        public virtual DbSet<Phancong> Phancong { get; set; }
        public virtual DbSet<Phanquyen> Phanquyen { get; set; }
        public virtual DbSet<Phongban> Phongban { get; set; }
        
        public virtual DbSet<Thuonghieu> Thuonghieu { get; set; }
        public virtual DbSet<Trangthai> Trangthai { get; set; }
        public virtual DbSet<Trangweb> Trangweb { get; set; }
        public virtual DbSet<Xuatxu> Xuatxu { get; set; }
        public virtual DbSet<Yeuthich> Yeuthich { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7RKV3V1\\SQLEXPRESS; Database=BACHHOA_ONLINE;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => e.Macthd);

                entity.ToTable("CHITIETHOADON");

                entity.Property(e => e.Macthd).HasColumnName("MACTHD");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Giamgia).HasColumnName("GIAMGIA");

                entity.Property(e => e.Mahd).HasColumnName("MAHD");

                entity.Property(e => e.Mahh).HasColumnName("MAHH");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MahdNavigation)
                    .WithMany(p => p.Chitiethoadon)
                    .HasForeignKey(d => d.Mahd)
                    .HasConstraintName("FK_CHITIETHOADON_HOADON");

                entity.HasOne(d => d.MahhNavigation)
                    .WithMany(p => p.Chitiethoadon)
                    .HasForeignKey(d => d.Mahh)
                    .HasConstraintName("FK_CHITIETHOADON_HANGHOA");
            });

            modelBuilder.Entity<Chitietloai>(entity =>
            {
                entity.HasKey(e => e.Mactl);

                entity.ToTable("CHITIETLOAI");

                entity.Property(e => e.Mactl).HasColumnName("MACTL");

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenctl)
                    .HasColumnName("TENCTL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Hanghoa>(entity =>
            {
                entity.HasKey(e => e.Mahh);

                entity.ToTable("HANGHOA");

                entity.Property(e => e.Mahh).HasColumnName("MAHH");

                entity.Property(e => e.Chitietloai).HasColumnName("CHITIETLOAI");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Giamgia).HasColumnName("GIAMGIA");

                entity.Property(e => e.Hinh)
                    .HasColumnName("HINH")
                    .HasMaxLength(255);

                entity.Property(e => e.Maloai).HasColumnName("MALOAI");

                entity.Property(e => e.Mancc).HasColumnName("MANCC");

                entity.Property(e => e.Math).HasColumnName("MATH");

                entity.Property(e => e.Maxx).HasColumnName("MAXX");

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasColumnType("text");

                entity.Property(e => e.Motadonvi)
                    .HasColumnName("MOTADONVI")
                    .HasMaxLength(100);

                entity.Property(e => e.Ngaysx)
                    .HasColumnName("NGAYSX")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Solanxem).HasColumnName("SOLANXEM");

                entity.Property(e => e.Tenalias)
                    .HasColumnName("TENALIAS")
                    .HasColumnType("text");

                entity.Property(e => e.Tenhh)
                    .HasColumnName("TENHH")
                    .HasColumnType("text");

                entity.HasOne(d => d.ChitietloaiNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Chitietloai)
                    .HasConstraintName("FK_HANGHOA_CHITIETLOAI");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK_HANGHOA_LOAI");

                entity.HasOne(d => d.ManccNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Mancc)
                    .HasConstraintName("FK_HANGHOA_NHACUNGCAP");

                entity.HasOne(d => d.MathNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Math)
                    .HasConstraintName("FK_HANGHOA_THUONGHIEU");

                entity.HasOne(d => d.MaxxNavigation)
                    .WithMany(p => p.Hanghoa)
                    .HasForeignKey(d => d.Maxx)
                    .HasConstraintName("FK_HANGHOA_XUATXU");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd);

                entity.ToTable("HOADON");

                entity.Property(e => e.Mahd).HasColumnName("MAHD");

                entity.Property(e => e.Cachthanhtoan)
                    .HasColumnName("CACHTHANHTOAN")
                    .HasMaxLength(100);

                entity.Property(e => e.Cachvanchuyen)
                    .HasColumnName("CACHVANCHUYEN")
                    .HasMaxLength(100);

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .HasColumnType("text");

                entity.Property(e => e.Hoten)
                    .HasColumnName("HOTEN")
                    .HasMaxLength(100);

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Matrangthai).HasColumnName("MATRANGTHAI");

                entity.Property(e => e.Ngaydat)
                    .HasColumnName("NGAYDAT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ngaygiao)
                    .HasColumnName("NGAYGIAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Phivanchuyen).HasColumnName("PHIVANCHUYEN");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK_HOADON_KHACHHANG");

                entity.HasOne(d => d.MatrangthaiNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Matrangthai)
                    .HasConstraintName("FK_HOADON_TRANGTHAI");
            });

            modelBuilder.Entity<Hotro>(entity =>
            {
                entity.HasKey(e => e.Maht);

                entity.ToTable("HOTRO");

                entity.Property(e => e.Maht).HasColumnName("MAHT");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Manx).HasColumnName("MANX");

                entity.Property(e => e.Ngaygui)
                    .HasColumnName("NGAYGUI")
                    .HasColumnType("datetime");

                entity.Property(e => e.Noidung)
                    .HasColumnName("NOIDUNG")
                    .HasColumnType("text");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hotro)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_HOTRO_NHANVIEN");

                entity.HasOne(d => d.ManxNavigation)
                    .WithMany(p => p.Hotro)
                    .HasForeignKey(d => d.Manx)
                    .HasConstraintName("FK_HOTRO_NHANXET");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh);

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255);

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("DIENTHOAI")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gioitinh).HasColumnName("GIOITINH");

                entity.Property(e => e.Hoten)
                    .HasColumnName("HOTEN")
                    .HasMaxLength(100);

                entity.Property(e => e.Matkhau)
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("datetime");

                entity.Property(e => e.Randomkey)
                    .HasColumnName("RANDOMKEY")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Loai>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("LOAI");

                entity.Property(e => e.Maloai).HasColumnName("MALOAI");

                entity.Property(e => e.Hinh)
                    .HasColumnName("HINH")
                    .HasMaxLength(100);

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasMaxLength(255);

                entity.Property(e => e.Tenloai)
                    .HasColumnName("TENLOAI")
                    .HasMaxLength(100);

                entity.Property(e => e.Tenloaialias)
                    .HasColumnName("TENLOAIALIAS")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.Mancc);

                entity.ToTable("NHACUNGCAP");

                entity.Property(e => e.Mancc).HasColumnName("MANCC");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(100);

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("DIENTHOAI")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Logo)
                    .HasColumnName("LOGO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasColumnType("text");

                entity.Property(e => e.Nguoilienhe)
                    .HasColumnName("NGUOILIENHE")
                    .HasMaxLength(100);

                entity.Property(e => e.Tenncc)
                    .HasColumnName("TENNCC")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv);

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Hoten)
                    .HasColumnName("HOTEN")
                    .HasMaxLength(100);

                entity.Property(e => e.Matkhau)
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Randomkey)
                    .HasColumnName("RANDOMKEY")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nhanxet>(entity =>
            {
                entity.HasKey(e => e.Manx);

                entity.ToTable("NHANXET");

                entity.Property(e => e.Manx).HasColumnName("MANX");

                entity.Property(e => e.Mahh).HasColumnName("MAHH");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Ngaygui)
                    .HasColumnName("NGAYGUI")
                    .HasColumnType("datetime");

                entity.Property(e => e.Noidung)
                    .HasColumnName("NOIDUNG")
                    .HasColumnType("text");

                entity.Property(e => e.Rating).HasColumnName("RATING");

                entity.HasOne(d => d.MahhNavigation)
                    .WithMany(p => p.Nhanxet)
                    .HasForeignKey(d => d.Mahh)
                    .HasConstraintName("FK_NHANXET_HANGHOA");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Nhanxet)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK_NHANXET_KHACHHANG");
            });

            modelBuilder.Entity<Phancong>(entity =>
            {
                entity.HasKey(e => e.Mapc);

                entity.ToTable("PHANCONG");

                entity.Property(e => e.Mapc).HasColumnName("MAPC");

                entity.Property(e => e.Hieuluc)
                    .HasColumnName("HIEULUC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Mapb).HasColumnName("MAPB");

                entity.Property(e => e.Ngaypc)
                    .HasColumnName("NGAYPC")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Phancong)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_PHANCONG_NHANVIEN");

                entity.HasOne(d => d.MapbNavigation)
                    .WithMany(p => p.Phancong)
                    .HasForeignKey(d => d.Mapb)
                    .HasConstraintName("FK_PHANCONG_PHONGBAN");
            });

            modelBuilder.Entity<Phanquyen>(entity =>
            {
                entity.HasKey(e => e.Mapq);

                entity.ToTable("PHANQUYEN");

                entity.Property(e => e.Mapq).HasColumnName("MAPQ");

                entity.Property(e => e.Mapb).HasColumnName("MAPB");

                entity.Property(e => e.Matrang).HasColumnName("MATRANG");

                entity.Property(e => e.Sua).HasColumnName("SUA");

                entity.Property(e => e.Them).HasColumnName("THEM");

                entity.Property(e => e.Xem).HasColumnName("XEM");

                entity.Property(e => e.Xoa).HasColumnName("XOA");

                entity.HasOne(d => d.MapbNavigation)
                    .WithMany(p => p.Phanquyen)
                    .HasForeignKey(d => d.Mapb)
                    .HasConstraintName("FK_PHANQUYEN_PHONGBAN");

                entity.HasOne(d => d.MatrangNavigation)
                    .WithMany(p => p.Phanquyen)
                    .HasForeignKey(d => d.Matrang)
                    .HasConstraintName("FK_PHANQUYEN_TRANGWEB");
            });

            modelBuilder.Entity<Phongban>(entity =>
            {
                entity.HasKey(e => e.Mapb);

                entity.ToTable("PHONGBAN");

                entity.Property(e => e.Mapb).HasColumnName("MAPB");

                entity.Property(e => e.Tenpb)
                    .HasColumnName("TENPB")
                    .HasMaxLength(100);

                entity.Property(e => e.Thontin)
                    .HasColumnName("THONTIN")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Thuonghieu>(entity =>
            {
                entity.HasKey(e => e.Math);

                entity.ToTable("THUONGHIEU");

                entity.Property(e => e.Math).HasColumnName("MATH");

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasColumnType("text");

                entity.Property(e => e.Tenth)
                    .HasColumnName("TENTH")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Trangthai>(entity =>
            {
                entity.HasKey(e => e.Matrangthai);

                entity.ToTable("TRANGTHAI");

                entity.Property(e => e.Matrangthai).HasColumnName("MATRANGTHAI");

                entity.Property(e => e.Motra)
                    .HasColumnName("MOTRA")
                    .HasColumnType("text");

                entity.Property(e => e.Tentrangthai)
                    .HasColumnName("TENTRANGTHAI")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Trangweb>(entity =>
            {
                entity.HasKey(e => e.Matrang);

                entity.ToTable("TRANGWEB");

                entity.Property(e => e.Matrang).HasColumnName("MATRANG");

                entity.Property(e => e.Tentrang)
                    .HasColumnName("TENTRANG")
                    .HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Xuatxu>(entity =>
            {
                entity.HasKey(e => e.Maxx);

                entity.ToTable("XUATXU");

                entity.Property(e => e.Maxx).HasColumnName("MAXX");

                entity.Property(e => e.Tenxx)
                    .HasColumnName("TENXX")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Yeuthich>(entity =>
            {
                entity.HasKey(e => e.Mayt);

                entity.ToTable("YEUTHICH");

                entity.Property(e => e.Mayt).HasColumnName("MAYT");

                entity.Property(e => e.Mahh).HasColumnName("MAHH");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Ngaychon)
                    .HasColumnName("NGAYCHON")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MahhNavigation)
                    .WithMany(p => p.Yeuthich)
                    .HasForeignKey(d => d.Mahh)
                    .HasConstraintName("FK_YEUTHICH_HANGHOA");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Yeuthich)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK_YEUTHICH_KHACHHANG");
            });
        }
    }
}
