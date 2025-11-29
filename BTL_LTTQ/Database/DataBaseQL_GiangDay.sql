

-- 1. Khoa (Tạo trước vì các bảng khác tham chiếu)
CREATE TABLE Khoa (
    MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

-- 2. Môn Học (Tham chiếu Khoa)
CREATE TABLE MonHoc (
    MaMH VARCHAR(10) PRIMARY KEY,
    TenMH NVARCHAR(100) NOT NULL,
    SoTC INT,
    SoTietLT INT,
    SoTietTH INT,
    HeSoDQT DECIMAL(3,2) NOT NULL,
    HeSoThi DECIMAL(3,2) NOT NULL,
    MaKhoa VARCHAR(10),
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

-- 3. Giảng Viên (Tham chiếu Khoa)
CREATE TABLE GiangVien (
    MaGV VARCHAR(10) PRIMARY KEY,
    TenGV NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    DiaChi NVARCHAR(255),
    NgaySinh DATE,
    TinhTrang NVARCHAR(50),
    HocHam NVARCHAR(50),
    HocVi NVARCHAR(50),
    MaKhoa VARCHAR(10),
    -- Các cột đã thêm
    GioiTinh NVARCHAR(10) NULL,
    Email VARCHAR(100) NULL,
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

-- 4. Sinh Viên (Tham chiếu Khoa)
CREATE TABLE SinhVien (
    MaSV VARCHAR(10) PRIMARY KEY,
    TenSV NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    SDT NVARCHAR(15),
    Email NVARCHAR(100),
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    QueQuan NVARCHAR(100),
    NgayNhapHoc DATE,
    MaKhoa VARCHAR(10),
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);

-- 11. Bảng Học Kỳ (Tạo trước)
-- Bảng này có khóa chính (HocKy, NamHoc) kiểu INT
-- để khớp chính xác với form của bạn.
CREATE TABLE HocKy (
    HocKy INT NOT NULL,          -- Ví dụ: 1, 2, 3 (là số học kỳ)
    NamHoc INT NOT NULL,         -- Ví dụ: 2025 (là năm học bắt đầu của học kỳ)

    TenHocKy NVARCHAR(100) NULL, -- Tên mô tả, ví dụ: 'Học kỳ 1 (2025-2026)'
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,

    -- Khóa chính MỚI, khớp với các control trên form
    PRIMARY KEY (HocKy, NamHoc),

    CONSTRAINT CK_HocKy_NgayHoc CHECK (NgayKetThuc >= NgayBatDau),
    CONSTRAINT CK_HocKy_GiaTri CHECK (HocKy IN (1, 2, 3))
);
GO

-- 5. Lớp tín chỉ (Tham chiếu Môn Học)
CREATE TABLE LopTinChi (
    MaLop VARCHAR(10) PRIMARY KEY,
    NamHoc INT,
    MaMH VARCHAR(10),

    -- Các cột đã thêm
    TinhTrangLop BIT DEFAULT 0, -- 0: chưa phân công, 1: đã phân công
    HocKy INT NULL, -- Sửa thành INT để khớp với HocKy trong bảng HocKy

    FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH), -- Đã thêm dấu phẩy
    FOREIGN KEY (HocKy, NamHoc) REFERENCES HocKy(HocKy, NamHoc) -- Đã sửa lỗi cú pháp
);

-- 6. Tài Khoản (Tham chiếu Giảng Viên)
CREATE TABLE TaiKhoan (
    MaTK VARCHAR(10) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(255) NOT NULL,
    LoaiTaiKhoan NVARCHAR(50),
    MaGV VARCHAR(10),
    FOREIGN KEY (MaGV) REFERENCES GiangVien(MaGV)
);

-- 7. Khu Vực
CREATE TABLE KhuVuc (
    MaKhuVuc VARCHAR(10) PRIMARY KEY,
    TenKhuVuc NVARCHAR(50) NOT NULL
);

-- 8. Phòng học
CREATE TABLE PhongHoc (
    MaPhong VARCHAR(20) PRIMARY KEY,  -- Ví dụ: A1-101, B-204, C-301
    MaKhuVuc VARCHAR(10),
    CONSTRAINT FK_PhongHoc_KhuVuc FOREIGN KEY (MaKhuVuc)
        REFERENCES KhuVuc(MaKhuVuc) ON DELETE CASCADE
);

-- 9. Phân công giảng dạy (Tham chiếu GV, Khoa, Lớp TC)
CREATE TABLE PhanCongGiangDay (
    MaPC VARCHAR(10) PRIMARY KEY,
    NgayPC DATE NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    CaHoc TINYINT NOT NULL,         -- 1..5
    Thu TINYINT NOT NULL,           -- 2..8 (2=Thứ Hai ... 8=Chủ Nhật)
    MaPhong VARCHAR(20) NOT NULL,
    MaGV VARCHAR(10) NOT NULL,
    MaLop VARCHAR(10) NOT NULL,
    CONSTRAINT FK_PhanCong_PhongHoc FOREIGN KEY (MaPhong)
        REFERENCES PhongHoc(MaPhong) ON DELETE CASCADE,
    CONSTRAINT FK_PhanCong_GiangVien FOREIGN KEY (MaGV)
        REFERENCES GiangVien(MaGV) ON DELETE CASCADE,
    CONSTRAINT FK_PhanCong_LopTinChi FOREIGN KEY (MaLop)
        REFERENCES LopTinChi(MaLop) ON DELETE CASCADE,
    CONSTRAINT CK_PhanCong_NgayHoc CHECK (NgayKetThuc >= NgayBatDau),
    CONSTRAINT CK_PhanCong_CaHoc CHECK (CaHoc BETWEEN 1 AND 5),
    CONSTRAINT CK_PhanCong_Thu CHECK (Thu BETWEEN 2 AND 8)
);

-- 10. Điểm (Tham chiếu Sinh Viên, Lớp TC)
CREATE TABLE Diem (
    MaSV VARCHAR(10),
    MaLop VARCHAR(10),
    DiemCC DECIMAL(4, 2),
    DiemGK DECIMAL(4, 2),
    DiemThi DECIMAL(4, 2),
    DiemKTHP DECIMAL(4, 2), -- Đã sửa từ DiemTB sang DiemKTHP

    PRIMARY KEY (MaSV, MaLop),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaLop) REFERENCES LopTinChi(MaLop)
);

-- ********************************************
-- 3. CHÈN DỮ LIỆU MẪU (SAMPLE DATA)
-- ********************************************

-- ================================================
-- DỮ LIỆU MẪU CHO HỆ THỐNG QUẢN LÝ GIẢNG DẠY
-- Database: QL_GiangDay
-- Ngày tạo: 28/11/2025
-- Format đơn giản, dễ hiểu
-- ================================================

USE QL_GiangDay;
GO

-- ================================================
-- XÓA DỮ LIỆU CŨ
-- ================================================
DELETE FROM Diem;
DELETE FROM PhanCongGiangDay;
DELETE FROM TaiKhoan;
DELETE FROM SinhVien;
DELETE FROM LopTinChi;
DELETE FROM GiangVien;
DELETE FROM MonHoc;
DELETE FROM PhongHoc;
DELETE FROM KhuVuc;
DELETE FROM HocKy;
DELETE FROM Khoa;
GO

PRINT N'🗑️ Đã xóa dữ liệu cũ';
GO

-- ================================================
-- 1. KHOA
-- ================================================
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES
('CNTT', N'Công nghệ Thông tin'),
('KTPM', N'Kỹ thuật Phần mềm'),
('KHMT', N'Khoa học Máy tính'),
('HTTT', N'Hệ thống Thông tin'),
('KT', N'Kinh tế'),
('XD', N'Xây dựng');
GO

PRINT N'✅ Đã thêm 6 Khoa';
GO

-- ================================================
-- 2. HỌC KỲ
-- ================================================
INSERT INTO HocKy (HocKy, NamHoc, TenHocKy, NgayBatDau, NgayKetThuc) VALUES
-- Năm 2024
(1, 2024, N'Học kỳ 1 (2024-2025)', '2024-09-02', '2025-01-18'),
(2, 2024, N'Học kỳ 2 (2024-2025)', '2025-02-03', '2025-06-20'),
(3, 2024, N'Học kỳ 3 (2024-2025)', '2025-07-07', '2025-08-30'),

-- Năm 2025 (Hiện tại)
(1, 2025, N'Học kỳ 1 (2025-2026)', '2025-09-01', '2026-01-16'),
(2, 2025, N'Học kỳ 2 (2025-2026)', '2026-02-02', '2026-06-19'),
(3, 2025, N'Học kỳ 3 (2025-2026)', '2026-07-06', '2026-08-28');
GO

PRINT N'✅ Đã thêm 6 Học kỳ';
GO

-- ================================================
-- 3. MÔN HỌC
-- ================================================
INSERT INTO MonHoc (MaMH, TenMH, SoTC, SoTietLT, SoTietTH, HeSoDQT, HeSoThi, MaKhoa) VALUES
-- CNTT
('MH001', N'Lập trình căn bản', 3, 30, 15, 0.30, 0.70, 'CNTT'),
('MH002', N'Cấu trúc dữ liệu', 4, 45, 15, 0.40, 0.60, 'CNTT'),
('MH003', N'Cơ sở dữ liệu', 3, 30, 15, 0.30, 0.70, 'CNTT'),
('MH004', N'Lập trình OOP', 4, 45, 15, 0.40, 0.60, 'CNTT'),
('MH005', N'Mạng máy tính', 3, 30, 15, 0.30, 0.70, 'CNTT'),

-- KTPM
('MH006', N'Công nghệ phần mềm', 3, 30, 15, 0.30, 0.70, 'KTPM'),
('MH007', N'Kiểm thử phần mềm', 3, 30, 15, 0.30, 0.70, 'KTPM'),
('MH008', N'Lập trình Web', 4, 30, 30, 0.30, 0.70, 'KTPM'),
('MH009', N'Lập trình Mobile', 4, 30, 30, 0.30, 0.70, 'KTPM'),
('MH010', N'Quản lý dự án', 3, 30, 15, 0.40, 0.60, 'KTPM'),

-- KHMT
('MH011', N'Toán rời rạc', 3, 45, 0, 0.30, 0.70, 'KHMT'),
('MH012', N'Xác suất thống kê', 3, 45, 0, 0.30, 0.70, 'KHMT'),
('MH013', N'Đại số tuyến tính', 3, 45, 0, 0.30, 0.70, 'KHMT'),
('MH014', N'Thuật toán', 4, 45, 15, 0.40, 0.60, 'KHMT'),
('MH015', N'Trí tuệ nhân tạo', 4, 45, 15, 0.40, 0.60, 'KHMT'),

-- HTTT
('MH016', N'Hệ quản trị CSDL', 4, 30, 30, 0.30, 0.70, 'HTTT'),
('MH017', N'Phân tích dữ liệu', 3, 30, 15, 0.40, 0.60, 'HTTT'),
('MH018', N'Business Intelligence', 4, 30, 30, 0.40, 0.60, 'HTTT'),
('MH019', N'Cloud Computing', 4, 30, 30, 0.40, 0.60, 'HTTT'),
('MH020', N'Big Data', 4, 30, 30, 0.40, 0.60, 'HTTT'),

-- KT
('MH021', N'Kinh tế vi mô', 3, 45, 0, 0.30, 0.70, 'KT'),
('MH022', N'Kinh tế vĩ mô', 3, 45, 0, 0.30, 0.70, 'KT'),
('MH023', N'Quản trị kinh doanh', 3, 30, 15, 0.40, 0.60, 'KT'),

-- XD
('MH024', N'Vẽ kỹ thuật', 3, 15, 30, 0.30, 0.70, 'XD'),
('MH025', N'Vật liệu xây dựng', 3, 30, 15, 0.30, 0.70, 'XD'),
('MH026', N'Thiết kế công trình', 4, 30, 30, 0.40, 0.60, 'XD');
GO

PRINT N'✅ Đã thêm 26 Môn học';
GO

-- ================================================
-- 4. GIẢNG VIÊN
-- ================================================
INSERT INTO GiangVien (MaGV, TenGV, SDT, DiaChi, NgaySinh, TinhTrang, HocHam, HocVi, MaKhoa, GioiTinh, Email) VALUES
-- CNTT (5 GV)
('GV001', N'Nguyễn Văn An', '0912345001', N'123 Lê Lợi, Q1, TP.HCM', '1980-05-15', N'Đang công tác', N'PGS', N'Tiến sĩ', 'CNTT', N'Nam', 'nva@university.edu.vn'),
('GV002', N'Trần Thị Bình', '0912345002', N'456 Nguyễn Huệ, Q1, TP.HCM', '1985-08-20', N'Đang công tác', N'Không', N'Thạc sĩ', 'CNTT', N'Nữ', 'ttb@university.edu.vn'),
('GV003', N'Lê Minh Cường', '0912345003', N'789 Trần Hưng Đạo, Q5, TP.HCM', '1978-03-10', N'Đang công tác', N'GS', N'Tiến sĩ', 'CNTT', N'Nam', 'lmc@university.edu.vn'),
('GV004', N'Phạm Thị Dung', '0912345004', N'321 Võ Văn Tần, Q3, TP.HCM', '1987-11-25', N'Đang công tác', N'Không', N'Tiến sĩ', 'CNTT', N'Nữ', 'ptd@university.edu.vn'),
('GV005', N'Hoàng Văn Em', '0912345005', N'654 Lý Thường Kiệt, Q10, TP.HCM', '1982-07-30', N'Đang công tác', N'PGS', N'Tiến sĩ', 'CNTT', N'Nam', 'hve@university.edu.vn'),

-- KTPM (5 GV)
('GV006', N'Đỗ Thị Phương', '0912345006', N'111 Hai Bà Trưng, Q1, TP.HCM', '1984-02-14', N'Đang công tác', N'Không', N'Thạc sĩ', 'KTPM', N'Nữ', 'dtp@university.edu.vn'),
('GV007', N'Ngô Văn Giang', '0912345007', N'222 Điện Biên Phủ, Q3, TP.HCM', '1981-09-05', N'Đang công tác', N'PGS', N'Tiến sĩ', 'KTPM', N'Nam', 'nvg@university.edu.vn'),
('GV008', N'Vũ Thị Hà', '0912345008', N'333 Cách Mạng Tháng 8, Q10, TP.HCM', '1986-12-18', N'Đang công tác', N'Không', N'Thạc sĩ', 'KTPM', N'Nữ', 'vth@university.edu.vn'),
('GV009', N'Bùi Văn Inh', '0912345009', N'444 Nguyễn Trãi, Q5, TP.HCM', '1983-04-22', N'Đang công tác', N'Không', N'Tiến sĩ', 'KTPM', N'Nam', 'bvi@university.edu.vn'),
('GV010', N'Đinh Thị Kim', '0912345010', N'555 Lê Văn Sỹ, Q3, TP.HCM', '1988-06-08', N'Đang công tác', N'Không', N'Thạc sĩ', 'KTPM', N'Nữ', 'dtk@university.edu.vn'),

-- KHMT (4 GV)
('GV011', N'Mai Văn Long', '0912345011', N'666 Phan Xích Long, PN, TP.HCM', '1979-01-12', N'Đang công tác', N'GS', N'Tiến sĩ', 'KHMT', N'Nam', 'mvl@university.edu.vn'),
('GV012', N'Phan Thị Minh', '0912345012', N'777 Cộng Hòa, TB, TP.HCM', '1985-10-28', N'Đang công tác', N'PGS', N'Tiến sĩ', 'KHMT', N'Nữ', 'ptm@university.edu.vn'),
('GV013', N'Trương Văn Nam', '0912345013', N'888 Hoàng Văn Thụ, TB, TP.HCM', '1980-03-17', N'Đang công tác', N'PGS', N'Tiến sĩ', 'KHMT', N'Nam', 'tvn@university.edu.vn'),
('GV014', N'Lý Thị Oanh', '0912345014', N'999 Trường Sơn, TB, TP.HCM', '1987-08-03', N'Đang công tác', N'Không', N'Thạc sĩ', 'KHMT', N'Nữ', 'lto@university.edu.vn'),

-- HTTT (4 GV)
('GV015', N'Cao Văn Phú', '0912345015', N'101 Nguyễn Văn Trỗi, PN, TP.HCM', '1982-11-09', N'Đang công tác', N'Không', N'Tiến sĩ', 'HTTT', N'Nam', 'cvp@university.edu.vn'),
('GV016', N'Huỳnh Thị Quỳnh', '0912345016', N'202 Võ Thị Sáu, Q3, TP.HCM', '1984-05-21', N'Đang công tác', N'PGS', N'Tiến sĩ', 'HTTT', N'Nữ', 'htq@university.edu.vn'),
('GV017', N'Đặng Văn Rồng', '0912345017', N'303 Pasteur, Q1, TP.HCM', '1981-12-14', N'Đang công tác', N'PGS', N'Tiến sĩ', 'HTTT', N'Nam', 'dvr@university.edu.vn'),
('GV018', N'Tạ Thị Sen', '0912345018', N'404 Nam Kỳ Khởi Nghĩa, Q1, TP.HCM', '1986-07-26', N'Đang công tác', N'Không', N'Thạc sĩ', 'HTTT', N'Nữ', 'tts@university.edu.vn'),

-- KT (2 GV)
('GV019', N'Võ Văn Tâm', '0912345019', N'505 Lý Tự Trọng, Q1, TP.HCM', '1983-02-19', N'Đang công tác', N'Không', N'Tiến sĩ', 'KT', N'Nam', 'vvt@university.edu.vn'),
('GV020', N'Dương Thị Uyên', '0912345020', N'606 Nguyễn Thị Minh Khai, Q3, TP.HCM', '1988-09-11', N'Đang công tác', N'Không', N'Thạc sĩ', 'KT', N'Nữ', 'dtu@university.edu.vn');
GO

PRINT N'✅ Đã thêm 20 Giảng viên';
GO

-- ================================================
-- 5. KHU VỰC VÀ PHÒNG HỌC
-- ================================================
INSERT INTO KhuVuc (MaKhuVuc, TenKhuVuc) VALUES
('A', N'Tòa A'),
('B', N'Tòa B'),
('C', N'Tòa C');
GO

INSERT INTO PhongHoc (MaPhong, MaKhuVuc) VALUES
('A101', 'A'), ('A102', 'A'), ('A103', 'A'), ('A104', 'A'), ('A105', 'A'),
('A106', 'A'), ('A107', 'A'), ('A108', 'A'), ('A109', 'A'), ('A110', 'A'),
('B101', 'B'), ('B102', 'B'), ('B103', 'B'), ('B104', 'B'), ('B105', 'B'),
('B106', 'B'), ('B107', 'B'), ('B108', 'B'), ('B109', 'B'), ('B110', 'B'),
('C201', 'C'), ('C202', 'C'), ('C203', 'C'), ('C204', 'C'), ('C205', 'C'),
('C206', 'C'), ('C207', 'C'), ('C208', 'C'), ('C209', 'C'), ('C210', 'C');
GO

PRINT N'✅ Đã thêm 3 Khu vực và 30 Phòng học';
GO

-- ================================================
-- 6. LỚP TÍN CHỈ
-- ================================================
INSERT INTO LopTinChi (MaLop, NamHoc, MaMH, TinhTrangLop, HocKy) VALUES
-- HK1/2025 - ĐÃ PHÂN CÔNG (20 lớp)
('LTC001', 2025, 'MH001', 1, 1),
('LTC002', 2025, 'MH001', 1, 1),
('LTC003', 2025, 'MH002', 1, 1),
('LTC004', 2025, 'MH003', 1, 1),
('LTC005', 2025, 'MH004', 1, 1),
('LTC006', 2025, 'MH005', 1, 1),
('LTC007', 2025, 'MH006', 1, 1),
('LTC008', 2025, 'MH007', 1, 1),
('LTC009', 2025, 'MH008', 1, 1),
('LTC010', 2025, 'MH009', 1, 1),
('LTC011', 2025, 'MH010', 1, 1),
('LTC012', 2025, 'MH011', 1, 1),
('LTC013', 2025, 'MH012', 1, 1),
('LTC014', 2025, 'MH013', 1, 1),
('LTC015', 2025, 'MH014', 1, 1),
('LTC016', 2025, 'MH015', 1, 1),
('LTC017', 2025, 'MH016', 1, 1),
('LTC018', 2025, 'MH017', 1, 1),
('LTC019', 2025, 'MH018', 1, 1),
('LTC020', 2025, 'MH019', 1, 1),

-- HK1/2025 - CHƯA PHÂN CÔNG (5 lớp)
('LTC021', 2025, 'MH020', 0, 1),
('LTC022', 2025, 'MH021', 0, 1),
('LTC023', 2025, 'MH022', 0, 1),
('LTC024', 2025, 'MH023', 0, 1),
('LTC025', 2025, 'MH024', 0, 1);
GO

PRINT N'✅ Đã thêm 25 Lớp tín chỉ (20 đã PC + 5 chưa PC)';
GO

-- ================================================
-- 7. PHÂN CÔNG GIẢNG DẠY - LỊCH ĐẦY ĐỦ
-- ================================================
INSERT INTO PhanCongGiangDay (MaPC, NgayPC, NgayBatDau, NgayKetThuc, CaHoc, Thu, MaPhong, MaGV, MaLop) VALUES
-- GV001 - 5 lớp
('PC001', '2025-08-25', '2025-09-01', '2026-01-16', 1, 2, 'A101', 'GV001', 'LTC001'), -- T2 Ca1
('PC002', '2025-08-25', '2025-09-01', '2026-01-16', 3, 2, 'A102', 'GV001', 'LTC002'), -- T2 Ca3
('PC003', '2025-08-25', '2025-09-01', '2026-01-16', 2, 4, 'B101', 'GV001', 'LTC003'), -- T4 Ca2
('PC004', '2025-08-25', '2025-09-01', '2026-01-16', 4, 5, 'C201', 'GV001', 'LTC004'), -- T5 Ca4
('PC005', '2025-08-25', '2025-09-01', '2026-01-16', 5, 6, 'A103', 'GV001', 'LTC005'), -- T6 Ca5

-- GV002 - 4 lớp
('PC006', '2025-08-25', '2025-09-01', '2026-01-16', 1, 3, 'A104', 'GV002', 'LTC006'), -- T3 Ca1
('PC007', '2025-08-25', '2025-09-01', '2026-01-16', 3, 4, 'B102', 'GV002', 'LTC007'), -- T4 Ca3
('PC008', '2025-08-25', '2025-09-01', '2026-01-16', 2, 5, 'C202', 'GV002', 'LTC008'), -- T5 Ca2
('PC009', '2025-08-25', '2025-09-01', '2026-01-16', 4, 6, 'A105', 'GV002', 'LTC009'), -- T6 Ca4

-- GV003 - 3 lớp
('PC010', '2025-08-25', '2025-09-01', '2026-01-16', 1, 2, 'B103', 'GV003', 'LTC010'), -- T2 Ca1
('PC011', '2025-08-25', '2025-09-01', '2026-01-16', 2, 3, 'C203', 'GV003', 'LTC011'), -- T3 Ca2
('PC012', '2025-08-25', '2025-09-01', '2026-01-16', 3, 5, 'A106', 'GV003', 'LTC012'), -- T5 Ca3

-- GV004 - 2 lớp
('PC013', '2025-08-25', '2025-09-01', '2026-01-16', 1, 4, 'B104', 'GV004', 'LTC013'), -- T4 Ca1
('PC014', '2025-08-25', '2025-09-01', '2026-01-16', 4, 3, 'C204', 'GV004', 'LTC014'), -- T3 Ca4

-- GV005 - 2 lớp
('PC015', '2025-08-25', '2025-09-01', '2026-01-16', 1, 5, 'A107', 'GV005', 'LTC015'), -- T5 Ca1
('PC016', '2025-08-25', '2025-09-01', '2026-01-16', 3, 6, 'B105', 'GV005', 'LTC016'), -- T6 Ca3

-- GV006 - 2 lớp
('PC017', '2025-08-25', '2025-09-01', '2026-01-16', 2, 2, 'C205', 'GV006', 'LTC017'), -- T2 Ca2
('PC018', '2025-08-25', '2025-09-01', '2026-01-16', 5, 4, 'A108', 'GV006', 'LTC018'), -- T4 Ca5

-- GV007 - 2 lớp
('PC019', '2025-08-25', '2025-09-01', '2026-01-16', 2, 6, 'B106', 'GV007', 'LTC019'), -- T6 Ca2
('PC020', '2025-08-25', '2025-09-01', '2026-01-16', 1, 6, 'C206', 'GV007', 'LTC020'); -- T6 Ca1
GO

PRINT N'✅ Đã thêm 20 Phân công giảng dạy';
GO

-- ================================================
-- 8. SINH VIÊN
-- ================================================
INSERT INTO SinhVien (MaSV, TenSV, NgaySinh, SDT, Email, GioiTinh, QueQuan, NgayNhapHoc, MaKhoa) VALUES
-- CNTT (20 SV)
('SV001', N'Nguyễn Văn Anh', '2002-03-15', '0912340001', 'sv001@student.edu.vn', N'Nam', N'Hà Nội', '2023-09-01', 'CNTT'),
('SV002', N'Trần Thị Bích', '2003-05-20', '0912340002', 'sv002@student.edu.vn', N'Nữ', N'TP.HCM', '2023-09-01', 'CNTT'),
('SV003', N'Lê Minh Cường', '2002-07-10', '0912340003', 'sv003@student.edu.vn', N'Nam', N'Đà Nẵng', '2023-09-01', 'CNTT'),
('SV004', N'Phạm Thị Dung', '2003-01-25', '0912340004', 'sv004@student.edu.vn', N'Nữ', N'Hải Phòng', '2023-09-01', 'CNTT'),
('SV005', N'Hoàng Văn Em', '2002-09-18', '0912340005', 'sv005@student.edu.vn', N'Nam', N'Cần Thơ', '2023-09-01', 'CNTT'),
('SV006', N'Đỗ Thị Phương', '2003-11-30', '0912340006', 'sv006@student.edu.vn', N'Nữ', N'Huế', '2023-09-01', 'CNTT'),
('SV007', N'Ngô Văn Giang', '2002-04-05', '0912340007', 'sv007@student.edu.vn', N'Nam', N'Nha Trang', '2023-09-01', 'CNTT'),
('SV008', N'Vũ Thị Hà', '2003-06-12', '0912340008', 'sv008@student.edu.vn', N'Nữ', N'Vũng Tàu', '2023-09-01', 'CNTT'),
('SV009', N'Bùi Văn Inh', '2002-08-22', '0912340009', 'sv009@student.edu.vn', N'Nam', N'Thanh Hóa', '2023-09-01', 'CNTT'),
('SV010', N'Đinh Thị Kim', '2003-02-14', '0912340010', 'sv010@student.edu.vn', N'Nữ', N'Nghệ An', '2023-09-01', 'CNTT'),
('SV011', N'Mai Văn Long', '2002-10-08', '0912340011', 'sv011@student.edu.vn', N'Nam', N'Quảng Ninh', '2023-09-01', 'CNTT'),
('SV012', N'Phan Thị Minh', '2003-12-03', '0912340012', 'sv012@student.edu.vn', N'Nữ', N'Bình Dương', '2023-09-01', 'CNTT'),
('SV013', N'Trương Văn Nam', '2002-05-27', '0912340013', 'sv013@student.edu.vn', N'Nam', N'Đồng Nai', '2023-09-01', 'CNTT'),
('SV014', N'Lý Thị Oanh', '2003-07-16', '0912340014', 'sv014@student.edu.vn', N'Nữ', N'Long An', '2023-09-01', 'CNTT'),
('SV015', N'Cao Văn Phú', '2002-09-09', '0912340015', 'sv015@student.edu.vn', N'Nam', N'Tiền Giang', '2023-09-01', 'CNTT'),
('SV016', N'Huỳnh Thị Quỳnh', '2003-03-21', '0912340016', 'sv016@student.edu.vn', N'Nữ', N'An Giang', '2023-09-01', 'CNTT'),
('SV017', N'Đặng Văn Rồng', '2002-11-11', '0912340017', 'sv017@student.edu.vn', N'Nam', N'Kiên Giang', '2023-09-01', 'CNTT'),
('SV018', N'Tạ Thị Sen', '2003-04-19', '0912340018', 'sv018@student.edu.vn', N'Nữ', N'Bà Rịa', '2023-09-01', 'CNTT'),
('SV019', N'Võ Văn Tâm', '2002-06-28', '0912340019', 'sv019@student.edu.vn', N'Nam', N'Bến Tre', '2023-09-01', 'CNTT'),
('SV020', N'Dương Thị Uyên', '2003-08-07', '0912340020', 'sv020@student.edu.vn', N'Nữ', N'Trà Vinh', '2023-09-01', 'CNTT'),

-- KTPM (15 SV)
('SV021', N'Nguyễn Thị Vân', '2002-01-10', '0912340021', 'sv021@student.edu.vn', N'Nữ', N'Hà Nội', '2023-09-01', 'KTPM'),
('SV022', N'Trần Văn Xuân', '2003-02-20', '0912340022', 'sv022@student.edu.vn', N'Nam', N'TP.HCM', '2023-09-01', 'KTPM'),
('SV023', N'Lê Thị Yến', '2002-03-30', '0912340023', 'sv023@student.edu.vn', N'Nữ', N'Đà Nẵng', '2023-09-01', 'KTPM'),
('SV024', N'Phạm Văn Zung', '2003-04-15', '0912340024', 'sv024@student.edu.vn', N'Nam', N'Hải Phòng', '2023-09-01', 'KTPM'),
('SV025', N'Hoàng Thị Ánh', '2002-05-25', '0912340025', 'sv025@student.edu.vn', N'Nữ', N'Cần Thơ', '2023-09-01', 'KTPM'),
('SV026', N'Đỗ Văn Bảo', '2003-06-05', '0912340026', 'sv026@student.edu.vn', N'Nam', N'Huế', '2023-09-01', 'KTPM'),
('SV027', N'Ngô Thị Chi', '2002-07-15', '0912340027', 'sv027@student.edu.vn', N'Nữ', N'Nha Trang', '2023-09-01', 'KTPM'),
('SV028', N'Vũ Văn Đạt', '2003-08-25', '0912340028', 'sv028@student.edu.vn', N'Nam', N'Vũng Tàu', '2023-09-01', 'KTPM'),
('SV029', N'Bùi Thị Em', '2002-09-05', '0912340029', 'sv029@student.edu.vn', N'Nữ', N'Thanh Hóa', '2023-09-01', 'KTPM'),
('SV030', N'Đinh Văn Phong', '2003-10-15', '0912340030', 'sv030@student.edu.vn', N'Nam', N'Nghệ An', '2023-09-01', 'KTPM'),
('SV031', N'Mai Thị Giang', '2002-11-25', '0912340031', 'sv031@student.edu.vn', N'Nữ', N'Quảng Ninh', '2023-09-01', 'KTPM'),
('SV032', N'Phan Văn Hải', '2003-12-05', '0912340032', 'sv032@student.edu.vn', N'Nam', N'Bình Dương', '2023-09-01', 'KTPM'),
('SV033', N'Trương Thị Hương', '2002-01-20', '0912340033', 'sv033@student.edu.vn', N'Nữ', N'Đồng Nai', '2023-09-01', 'KTPM'),
('SV034', N'Lý Văn Khang', '2003-02-28', '0912340034', 'sv034@student.edu.vn', N'Nam', N'Long An', '2023-09-01', 'KTPM'),
('SV035', N'Cao Thị Lan', '2002-03-18', '0912340035', 'sv035@student.edu.vn', N'Nữ', N'Tiền Giang', '2023-09-01', 'KTPM'),

-- KHMT (10 SV)
('SV036', N'Huỳnh Văn Minh', '2002-04-08', '0912340036', 'sv036@student.edu.vn', N'Nam', N'An Giang', '2023-09-01', 'KHMT'),
('SV037', N'Đặng Thị Ngọc', '2003-05-18', '0912340037', 'sv037@student.edu.vn', N'Nữ', N'Kiên Giang', '2023-09-01', 'KHMT'),
('SV038', N'Tạ Văn Oanh', '2002-06-28', '0912340038', 'sv038@student.edu.vn', N'Nam', N'Bà Rịa', '2023-09-01', 'KHMT'),
('SV039', N'Võ Thị Phương', '2003-07-08', '0912340039', 'sv039@student.edu.vn', N'Nữ', N'Bến Tre', '2023-09-01', 'KHMT'),
('SV040', N'Dương Văn Quân', '2002-08-18', '0912340040', 'sv040@student.edu.vn', N'Nam', N'Trà Vinh', '2023-09-01', 'KHMT'),
('SV041', N'Nguyễn Thị Rạng', '2003-09-28', '0912340041', 'sv041@student.edu.vn', N'Nữ', N'Hà Nội', '2023-09-01', 'KHMT'),
('SV042', N'Trần Văn Sơn', '2002-10-08', '0912340042', 'sv042@student.edu.vn', N'Nam', N'TP.HCM', '2023-09-01', 'KHMT'),
('SV043', N'Lê Thị Thảo', '2003-11-18', '0912340043', 'sv043@student.edu.vn', N'Nữ', N'Đà Nẵng', '2023-09-01', 'KHMT'),
('SV044', N'Phạm Văn Uyên', '2002-12-28', '0912340044', 'sv044@student.edu.vn', N'Nam', N'Hải Phòng', '2023-09-01', 'KHMT'),
('SV045', N'Hoàng Thị Vân', '2003-01-08', '0912340045', 'sv045@student.edu.vn', N'Nữ', N'Cần Thơ', '2023-09-01', 'KHMT'),

-- HTTT (10 SV)
('SV046', N'Đỗ Văn Xuân', '2002-02-18', '0912340046', 'sv046@student.edu.vn', N'Nam', N'Huế', '2023-09-01', 'HTTT'),
('SV047', N'Ngô Thị Yến', '2003-03-28', '0912340047', 'sv047@student.edu.vn', N'Nữ', N'Nha Trang', '2023-09-01', 'HTTT'),
('SV048', N'Vũ Văn Zung', '2002-04-18', '0912340048', 'sv048@student.edu.vn', N'Nam', N'Vũng Tàu', '2023-09-01', 'HTTT'),
('SV049', N'Bùi Thị Ánh', '2003-05-28', '0912340049', 'sv049@student.edu.vn', N'Nữ', N'Thanh Hóa', '2023-09-01', 'HTTT'),
('SV050', N'Đinh Văn Bảo', '2002-06-08', '0912340050', 'sv050@student.edu.vn', N'Nam', N'Nghệ An', '2023-09-01', 'HTTT'),
('SV051', N'Mai Thị Chi', '2003-07-18', '0912340051', 'sv051@student.edu.vn', N'Nữ', N'Quảng Ninh', '2023-09-01', 'HTTT'),
('SV052', N'Phan Văn Đạt', '2002-08-28', '0912340052', 'sv052@student.edu.vn', N'Nam', N'Bình Dương', '2023-09-01', 'HTTT'),
('SV053', N'Trương Thị Em', '2003-09-08', '0912340053', 'sv053@student.edu.vn', N'Nữ', N'Đồng Nai', '2023-09-01', 'HTTT'),
('SV054', N'Lý Văn Phong', '2002-10-18', '0912340054', 'sv054@student.edu.vn', N'Nam', N'Long An', '2023-09-01', 'HTTT'),
('SV055', N'Cao Thị Giang', '2003-11-28', '0912340055', 'sv055@student.edu.vn', N'Nữ', N'Tiền Giang', '2023-09-01', 'HTTT'),

-- KT (5 SV)
('SV056', N'Huỳnh Văn Hải', '2002-12-08', '0912340056', 'sv056@student.edu.vn', N'Nam', N'An Giang', '2023-09-01', 'KT'),
('SV057', N'Đặng Thị Hương', '2003-01-18', '0912340057', 'sv057@student.edu.vn', N'Nữ', N'Kiên Giang', '2023-09-01', 'KT'),
('SV058', N'Tạ Văn Khang', '2002-02-28', '0912340058', 'sv058@student.edu.vn', N'Nam', N'Bà Rịa', '2023-09-01', 'KT'),
('SV059', N'Võ Thị Lan', '2003-03-10', '0912340059', 'sv059@student.edu.vn', N'Nữ', N'Bến Tre', '2023-09-01', 'KT'),
('SV060', N'Dương Văn Minh', '2002-04-20', '0912340060', 'sv060@student.edu.vn', N'Nam', N'Trà Vinh', '2023-09-01', 'KT');
GO

PRINT N'✅ Đã thêm 60 Sinh viên';
GO

-- ================================================
-- 9. ĐIỂM - THEO FORMAT YÊU CẦU
-- ================================================
INSERT INTO Diem (MaSV, MaLop, DiemCC, DiemGK, DiemThi, DiemKTHP) VALUES
-- LTC001 (Lập trình căn bản) - 5 SV
('SV001', 'LTC001', 9.00, 7.50, 8.00, 8.13),
('SV002', 'LTC001', 8.00, 6.50, 7.00, 7.00),
('SV003', 'LTC001', 7.50, 8.00, 7.50, 7.65),
('SV004', 'LTC001', 6.00, 7.00, 6.50, 6.60),
('SV005', 'LTC001', 8.50, 8.50, 9.00, 8.73),

-- LTC002 (Lập trình căn bản) - 5 SV
('SV006', 'LTC002', 9.50, 8.00, 8.50, 8.60),
('SV007', 'LTC002', 7.00, 7.50, 7.00, 7.15),
('SV008', 'LTC002', 8.00, 7.00, 7.50, 7.45),
('SV009', 'LTC002', 6.50, 6.00, 6.50, 6.35),
('SV010', 'LTC002', 9.00, 9.00, 9.50, 9.25),

-- LTC003 (Cấu trúc dữ liệu) - 5 SV
('SV011', 'LTC003', 8.50, 7.50, 8.00, 7.95),
('SV012', 'LTC003', 7.00, 6.50, 7.00, 6.80),
('SV013', 'LTC003', 9.00, 8.50, 8.50, 8.60),
('SV014', 'LTC003', 6.00, 7.00, 6.00, 6.30),
('SV015', 'LTC003', 8.00, 8.00, 8.50, 8.25),

-- LTC004 (Cơ sở dữ liệu) - 5 SV
('SV016', 'LTC004', 7.50, 7.00, 7.50, 7.35),
('SV017', 'LTC004', 8.00, 8.50, 8.00, 8.15),
('SV018', 'LTC004', 9.00, 7.50, 8.50, 8.43),
('SV019', 'LTC004', 6.50, 6.00, 6.50, 6.35),
('SV020', 'LTC004', 7.00, 7.50, 7.00, 7.15),

-- LTC005 (Lập trình OOP) - 5 SV
('SV001', 'LTC005', 8.50, 8.00, 8.50, 8.35),
('SV002', 'LTC005', 7.50, 7.00, 7.50, 7.35),
('SV003', 'LTC005', 9.00, 8.50, 9.00, 8.85),
('SV004', 'LTC005', 6.00, 6.50, 6.00, 6.15),
('SV005', 'LTC005', 8.00, 7.50, 8.00, 7.85),

-- LTC006 (Mạng máy tính) - 5 SV
('SV021', 'LTC006', 7.00, 7.50, 7.00, 7.15),
('SV022', 'LTC006', 8.50, 8.00, 8.50, 8.35),
('SV023', 'LTC006', 9.00, 8.50, 9.00, 8.85),
('SV024', 'LTC006', 6.50, 6.00, 6.50, 6.35),
('SV025', 'LTC006', 7.50, 7.00, 7.50, 7.35),

-- LTC007 (Công nghệ phần mềm) - 5 SV
('SV026', 'LTC007', 8.00, 7.50, 8.00, 7.85),
('SV027', 'LTC007', 7.00, 6.50, 7.00, 6.80),
('SV028', 'LTC007', 9.50, 9.00, 9.50, 9.35),
('SV029', 'LTC007', 6.00, 6.00, 6.00, 6.00),
('SV030', 'LTC007', 8.50, 8.00, 8.50, 8.35),

-- LTC008 (Kiểm thử phần mềm) - 5 SV
('SV031', 'LTC008', 7.50, 7.00, 7.50, 7.35),
('SV032', 'LTC008', 8.00, 8.50, 8.00, 8.15),
('SV033', 'LTC008', 9.00, 8.00, 9.00, 8.70),
('SV034', 'LTC008', 6.50, 6.50, 6.50, 6.50),
('SV035', 'LTC008', 7.00, 7.50, 7.00, 7.15),

-- LTC009 (Lập trình Web) - 5 SV
('SV021', 'LTC009', 8.50, 8.00, 8.50, 8.35),
('SV022', 'LTC009', 7.50, 7.00, 7.50, 7.35),
('SV023', 'LTC009', 9.00, 9.00, 9.50, 9.25),
('SV024', 'LTC009', 6.00, 6.00, 6.00, 6.00),
('SV025', 'LTC009', 8.00, 7.50, 8.00, 7.85),

-- LTC010 (Lập trình Mobile) - 5 SV
('SV026', 'LTC010', 7.00, 7.50, 7.00, 7.15),
('SV027', 'LTC010', 8.50, 8.00, 8.50, 8.35),
('SV028', 'LTC010', 9.00, 8.50, 9.00, 8.85),
('SV029', 'LTC010', 6.50, 6.00, 6.50, 6.35),
('SV030', 'LTC010', 7.50, 7.00, 7.50, 7.35),

-- LTC011 (Quản lý dự án) - 5 SV
('SV036', 'LTC011', 8.00, 7.50, 8.00, 7.90),
('SV037', 'LTC011', 7.00, 6.50, 7.00, 6.90),
('SV038', 'LTC011', 9.00, 8.50, 9.00, 8.90),
('SV039', 'LTC011', 6.00, 6.00, 6.00, 6.00),
('SV040', 'LTC011', 8.50, 8.00, 8.50, 8.40),

-- LTC012 (Toán rời rạc) - 5 SV
('SV041', 'LTC012', 7.50, 7.00, 7.50, 7.35),
('SV042', 'LTC012', 8.00, 8.50, 8.00, 8.15),
('SV043', 'LTC012', 9.00, 8.00, 9.00, 8.70),
('SV044', 'LTC012', 6.50, 6.50, 6.50, 6.50),
('SV045', 'LTC012', 7.00, 7.50, 7.00, 7.15),

-- LTC013 (Xác suất thống kê) - 5 SV
('SV036', 'LTC013', 8.50, 8.00, 8.50, 8.35),
('SV037', 'LTC013', 7.50, 7.00, 7.50, 7.35),
('SV038', 'LTC013', 9.00, 9.00, 9.50, 9.25),
('SV039', 'LTC013', 6.00, 6.00, 6.00, 6.00),
('SV040', 'LTC013', 8.00, 7.50, 8.00, 7.85),

-- LTC014 (Đại số tuyến tính) - 5 SV
('SV041', 'LTC014', 7.00, 7.50, 7.00, 7.15),
('SV042', 'LTC014', 8.50, 8.00, 8.50, 8.35),
('SV043', 'LTC014', 9.00, 8.50, 9.00, 8.85),
('SV044', 'LTC014', 6.50, 6.00, 6.50, 6.35),
('SV045', 'LTC014', 7.50, 7.00, 7.50, 7.35),

-- LTC015 (Thuật toán) - 5 SV
('SV046', 'LTC015', 8.00, 7.50, 8.00, 7.90),
('SV047', 'LTC015', 7.00, 6.50, 7.00, 6.90),
('SV048', 'LTC015', 9.00, 8.50, 9.00, 8.90),
('SV049', 'LTC015', 6.00, 6.00, 6.00, 6.00),
('SV050', 'LTC015', 8.50, 8.00, 8.50, 8.40),

-- LTC016 (Trí tuệ nhân tạo) - 5 SV
('SV051', 'LTC016', 7.50, 7.00, 7.50, 7.35),
('SV052', 'LTC016', 8.00, 8.50, 8.00, 8.15),
('SV053', 'LTC016', 9.00, 8.00, 9.00, 8.70),
('SV054', 'LTC016', 6.50, 6.50, 6.50, 6.50),
('SV055', 'LTC016', 7.00, 7.50, 7.00, 7.15),

-- LTC017 (Hệ quản trị CSDL) - 5 SV
('SV046', 'LTC017', 8.50, 8.00, 8.50, 8.35),
('SV047', 'LTC017', 7.50, 7.00, 7.50, 7.35),
('SV048', 'LTC017', 9.00, 9.00, 9.50, 9.25),
('SV049', 'LTC017', 6.00, 6.00, 6.00, 6.00),
('SV050', 'LTC017', 8.00, 7.50, 8.00, 7.85),

-- LTC018 (Phân tích dữ liệu) - 5 SV
('SV051', 'LTC018', 7.00, 7.50, 7.00, 7.20),
('SV052', 'LTC018', 8.50, 8.00, 8.50, 8.40),
('SV053', 'LTC018', 9.00, 8.50, 9.00, 8.90),
('SV054', 'LTC018', 6.50, 6.00, 6.50, 6.40),
('SV055', 'LTC018', 7.50, 7.00, 7.50, 7.40),

-- LTC019 (Business Intelligence) - 5 SV
('SV046', 'LTC019', 8.00, 7.50, 8.00, 7.90),
('SV047', 'LTC019', 7.00, 6.50, 7.00, 6.90),
('SV048', 'LTC019', 9.00, 8.50, 9.00, 8.90),
('SV049', 'LTC019', 6.00, 6.00, 6.00, 6.00),
('SV050', 'LTC019', 8.50, 8.00, 8.50, 8.40),

-- LTC020 (Cloud Computing) - 5 SV
('SV051', 'LTC020', 7.50, 7.00, 7.50, 7.40),
('SV052', 'LTC020', 8.00, 8.50, 8.00, 8.20),
('SV053', 'LTC020', 9.00, 8.00, 9.00, 8.80),
('SV054', 'LTC020', 6.50, 6.50, 6.50, 6.50),
('SV055', 'LTC020', 7.00, 7.50, 7.00, 7.20);
GO

PRINT N'✅ Đã thêm 100 bản ghi Điểm (20 lớp × 5 SV/lớp)';
GO

-- ================================================
-- 10. TÀI KHOẢN
-- ================================================
INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhau, LoaiTaiKhoan, MaGV) VALUES
('TK000', 'admin', '123456', N'Admin', NULL),
('TK001', 'gv001', '123456', N'Giảng viên', 'GV001'),
('TK002', 'gv002', '123456', N'Giảng viên', 'GV002'),
('TK003', 'gv003', '123456', N'Giảng viên', 'GV003'),
('TK004', 'gv004', '123456', N'Giảng viên', 'GV004'),
('TK005', 'gv005', '123456', N'Giảng viên', 'GV005'),
('TK006', 'gv006', '123456', N'Giảng viên', 'GV006'),
('TK007', 'gv007', '123456', N'Giảng viên', 'GV007'),
('TK008', 'gv008', '123456', N'Giảng viên', 'GV008'),
('TK009', 'gv009', '123456', N'Giảng viên', 'GV009'),
('TK010', 'gv010', '123456', N'Giảng viên', 'GV010'),
('TK011', 'gv011', '123456', N'Giảng viên', 'GV011'),
('TK012', 'gv012', '123456', N'Giảng viên', 'GV012'),
('TK013', 'gv013', '123456', N'Giảng viên', 'GV013'),
('TK014', 'gv014', '123456', N'Giảng viên', 'GV014'),
('TK015', 'gv015', '123456', N'Giảng viên', 'GV015'),
('TK016', 'gv016', '123456', N'Giảng viên', 'GV016'),
('TK017', 'gv017', '123456', N'Giảng viên', 'GV017'),
('TK018', 'gv018', '123456', N'Giảng viên', 'GV018'),
('TK019', 'gv019', '123456', N'Giảng viên', 'GV019'),
('TK020', 'gv020', '123456', N'Giảng viên', 'GV020');
GO

PRINT N'✅ Đã thêm 21 Tài khoản (1 Admin + 20 GV)';
GO


-- ================================================
-- 8.1. THÊM THÊM 60 SINH VIÊN (SV061 - SV120)
-- ================================================
INSERT INTO SinhVien (MaSV, TenSV, NgaySinh, SDT, Email, GioiTinh, QueQuan, NgayNhapHoc, MaKhoa) VALUES
-- CNTT (10 SV)
('SV061', N'Nguyễn Văn Bắc', '2002-05-11', '0912340061', 'sv061@student.edu.vn', N'Nam', N'Hà Nội', '2023-09-01', 'CNTT'),
('SV062', N'Trần Thị Cúc', '2003-02-19', '0912340062', 'sv062@student.edu.vn', N'Nữ', N'Hải Phòng', '2023-09-01', 'CNTT'),
('SV063', N'Lê Văn Dũng', '2002-07-23', '0912340063', 'sv063@student.edu.vn', N'Nam', N'Nam Định', '2023-09-01', 'CNTT'),
('SV064', N'Phạm Thị Em', '2003-01-09', '0912340064', 'sv064@student.edu.vn', N'Nữ', N'Thái Bình', '2023-09-01', 'CNTT'),
('SV065', N'Hoàng Văn Giáp', '2002-03-04', '0912340065', 'sv065@student.edu.vn', N'Nam', N'Quảng Ninh', '2023-09-01', 'CNTT'),
('SV066', N'Đỗ Thị Hạnh', '2003-09-16', '0912340066', 'sv066@student.edu.vn', N'Nữ', N'TP.HCM', '2023-09-01', 'CNTT'),
('SV067', N'Ngô Văn Kiên', '2002-11-28', '0912340067', 'sv067@student.edu.vn', N'Nam', N'Đà Nẵng', '2023-09-01', 'CNTT'),
('SV068', N'Vũ Thị Loan', '2003-06-06', '0912340068', 'sv068@student.edu.vn', N'Nữ', N'Cần Thơ', '2023-09-01', 'CNTT'),
('SV069', N'Bùi Văn Mạnh', '2002-08-14', '0912340069', 'sv069@student.edu.vn', N'Nam', N'Nghệ An', '2023-09-01', 'CNTT'),
('SV070', N'Đinh Thị Nga', '2003-10-21', '0912340070', 'sv070@student.edu.vn', N'Nữ', N'Thanh Hóa', '2023-09-01', 'CNTT'),

-- KTPM (10 SV)
('SV071', N'Mai Văn Phúc', '2002-01-17', '0912340071', 'sv071@student.edu.vn', N'Nam', N'Hà Nội', '2023-09-01', 'KTPM'),
('SV072', N'Phan Thị Quyên', '2003-03-29', '0912340072', 'sv072@student.edu.vn', N'Nữ', N'Hải Dương', '2023-09-01', 'KTPM'),
('SV073', N'Trương Văn Sơn', '2002-05-08', '0912340073', 'sv073@student.edu.vn', N'Nam', N'Bắc Ninh', '2023-09-01', 'KTPM'),
('SV074', N'Lý Thị Trang', '2003-07-13', '0912340074', 'sv074@student.edu.vn', N'Nữ', N'TP.HCM', '2023-09-01', 'KTPM'),
('SV075', N'Cao Văn Uy',  '2002-09-19', '0912340075', 'sv075@student.edu.vn', N'Nam', N'Đà Nẵng', '2023-09-01', 'KTPM'),
('SV076', N'Huỳnh Thị Vân', '2003-11-25', '0912340076', 'sv076@student.edu.vn', N'Nữ', N'Cần Thơ', '2023-09-01', 'KTPM'),
('SV077', N'Đặng Văn Xuyên', '2002-02-07', '0912340077', 'sv077@student.edu.vn', N'Nam', N'Huế', '2023-09-01', 'KTPM'),
('SV078', N'Tạ Thị Yến', '2003-04-18', '0912340078', 'sv078@student.edu.vn', N'Nữ', N'Quảng Nam', '2023-09-01', 'KTPM'),
('SV079', N'Võ Văn Zinh', '2002-06-26', '0912340079', 'sv079@student.edu.vn', N'Nam', N'Bình Định', '2023-09-01', 'KTPM'),
('SV080', N'Dương Thị Ánh', '2003-08-30', '0912340080', 'sv080@student.edu.vn', N'Nữ', N'Khánh Hòa', '2023-09-01', 'KTPM'),

-- KHMT (10 SV)
('SV081', N'Nguyễn Văn Bình', '2002-03-03', '0912340081', 'sv081@student.edu.vn', N'Nam', N'Hà Tĩnh', '2023-09-01', 'KHMT'),
('SV082', N'Trần Thị Châu', '2003-05-12', '0912340082', 'sv082@student.edu.vn', N'Nữ', N'Ninh Bình', '2023-09-01', 'KHMT'),
('SV083', N'Lê Văn Duy', '2002-07-21', '0912340083', 'sv083@student.edu.vn', N'Nam', N'Quảng Bình', '2023-09-01', 'KHMT'),
('SV084', N'Phạm Thị Hòa', '2003-09-09', '0912340084', 'sv084@student.edu.vn', N'Nữ', N'Quảng Trị', '2023-09-01', 'KHMT'),
('SV085', N'Hoàng Văn Khoa', '2002-11-16', '0912340085', 'sv085@student.edu.vn', N'Nam', N'Gia Lai', '2023-09-01', 'KHMT'),
('SV086', N'Đỗ Thị Liên', '2003-01-27', '0912340086', 'sv086@student.edu.vn', N'Nữ', N'Kon Tum', '2023-09-01', 'KHMT'),
('SV087', N'Ngô Văn Mậu', '2002-04-06', '0912340087', 'sv087@student.edu.vn', N'Nam', N'Lâm Đồng', '2023-09-01', 'KHMT'),
('SV088', N'Vũ Thị Nhung', '2003-06-15', '0912340088', 'sv088@student.edu.vn', N'Nữ', N'Bình Thuận', '2023-09-01', 'KHMT'),
('SV089', N'Bùi Văn Phi', '2002-08-24', '0912340089', 'sv089@student.edu.vn', N'Nam', N'Phú Yên', '2023-09-01', 'KHMT'),
('SV090', N'Đinh Thị Quỳnh', '2003-10-02', '0912340090', 'sv090@student.edu.vn', N'Nữ', N'An Giang', '2023-09-01', 'KHMT'),

-- HTTT (10 SV)
('SV091', N'Mai Văn Sinh', '2002-12-11', '0912340091', 'sv091@student.edu.vn', N'Nam', N'Kiên Giang', '2023-09-01', 'HTTT'),
('SV092', N'Phan Thị Thảo', '2003-02-22', '0912340092', 'sv092@student.edu.vn', N'Nữ', N'Sóc Trăng', '2023-09-01', 'HTTT'),
('SV093', N'Trương Văn Uy', '2002-04-30', '0912340093', 'sv093@student.edu.vn', N'Nam', N'Bạc Liêu', '2023-09-01', 'HTTT'),
('SV094', N'Lý Thị Vui', '2003-07-07', '0912340094', 'sv094@student.edu.vn', N'Nữ', N'Cà Mau', '2023-09-01', 'HTTT'),
('SV095', N'Cao Văn Xuân', '2002-09-14', '0912340095', 'sv095@student.edu.vn', N'Nam', N'Lai Châu', '2023-09-01', 'HTTT'),
('SV096', N'Huỳnh Thị Yên', '2003-11-23', '0912340096', 'sv096@student.edu.vn', N'Nữ', N'Sơn La', '2023-09-01', 'HTTT'),
('SV097', N'Đặng Văn An', '2002-01-05', '0912340097', 'sv097@student.edu.vn', N'Nam', N'Điện Biên', '2023-09-01', 'HTTT'),
('SV098', N'Tạ Thị Bình', '2003-03-17', '0912340098', 'sv098@student.edu.vn', N'Nữ', N'Lạng Sơn', '2023-09-01', 'HTTT'),
('SV099', N'Võ Văn Chiến', '2002-05-26', '0912340099', 'sv099@student.edu.vn', N'Nam', N'Cao Bằng', '2023-09-01', 'HTTT'),
('SV100', N'Dương Thị Diệu', '2003-08-04', '0912340100', 'sv100@student.edu.vn', N'Nữ', N'Hà Giang', '2023-09-01', 'HTTT'),

-- KT (10 SV)
('SV101', N'Nguyễn Văn Đạo', '2002-10-12', '0912340101', 'sv101@student.edu.vn', N'Nam', N'Hà Nội', '2023-09-01', 'KT'),
('SV102', N'Trần Thị Em', '2003-12-20', '0912340102', 'sv102@student.edu.vn', N'Nữ', N'Hải Phòng', '2023-09-01', 'KT'),
('SV103', N'Lê Văn Giang', '2002-02-01', '0912340103', 'sv103@student.edu.vn', N'Nam', N'Nghệ An', '2023-09-01', 'KT'),
('SV104', N'Phạm Thị Hạnh', '2003-04-09', '0912340104', 'sv104@student.edu.vn', N'Nữ', N'Thanh Hóa', '2023-09-01', 'KT'),
('SV105', N'Hoàng Văn Kỳ', '2002-06-18', '0912340105', 'sv105@student.edu.vn', N'Nam', N'TP.HCM', '2023-09-01', 'KT'),
('SV106', N'Đỗ Thị Lan', '2003-08-26', '0912340106', 'sv106@student.edu.vn', N'Nữ', N'Bình Dương', '2023-09-01', 'KT'),
('SV107', N'Ngô Văn Minh', '2002-11-03', '0912340107', 'sv107@student.edu.vn', N'Nam', N'Đồng Nai', '2023-09-01', 'KT'),
('SV108', N'Vũ Thị Nga', '2003-01-14', '0912340108', 'sv108@student.edu.vn', N'Nữ', N'Bà Rịa - Vũng Tàu', '2023-09-01', 'KT'),
('SV109', N'Bùi Văn Oai', '2002-03-22', '0912340109', 'sv109@student.edu.vn', N'Nam', N'Kiên Giang', '2023-09-01', 'KT'),
('SV110', N'Đinh Thị Phương', '2003-05-30', '0912340110', 'sv110@student.edu.vn', N'Nữ', N'An Giang', '2023-09-01', 'KT'),

-- XD (10 SV)
('SV111', N'Nguyễn Văn Quảng', '2002-07-07', '0912340111', 'sv111@student.edu.vn', N'Nam', N'Hà Nội', '2023-09-01', 'XD'),
('SV112', N'Trần Thị Rạng', '2003-09-15', '0912340112', 'sv112@student.edu.vn', N'Nữ', N'Hải Phòng', '2023-09-01', 'XD'),
('SV113', N'Lê Văn Sỹ', '2002-11-24', '0912340113', 'sv113@student.edu.vn', N'Nam', N'Nam Định', '2023-09-01', 'XD'),
('SV114', N'Phạm Thị Thanh', '2003-01-02', '0912340114', 'sv114@student.edu.vn', N'Nữ', N'Ninh Bình', '2023-09-01', 'XD'),
('SV115', N'Hoàng Văn Trung', '2002-03-11', '0912340115', 'sv115@student.edu.vn', N'Nam', N'Thái Bình', '2023-09-01', 'XD'),
('SV116', N'Đỗ Thị Uyên', '2003-05-19', '0912340116', 'sv116@student.edu.vn', N'Nữ', N'Quảng Ninh', '2023-09-01', 'XD'),
('SV117', N'Ngô Văn Vượng', '2002-07-28', '0912340117', 'sv117@student.edu.vn', N'Nam', N'Đà Nẵng', '2023-09-01', 'XD'),
('SV118', N'Vũ Thị Xoan', '2003-10-06', '0912340118', 'sv118@student.edu.vn', N'Nữ', N'TP.HCM', '2023-09-01', 'XD'),
('SV119', N'Bùi Văn Yên', '2002-12-14', '0912340119', 'sv119@student.edu.vn', N'Nam', N'Cần Thơ', '2023-09-01', 'XD'),
('SV120', N'Đinh Thị Zung', '2003-02-23', '0912340120', 'sv120@student.edu.vn', N'Nữ', N'Khánh Hòa', '2023-09-01', 'XD');
GO

PRINT N'✅ Đã thêm thêm 60 Sinh viên (tổng ~120 SV)';
GO

-- ================================================
-- 9.1. TỰ ĐỘNG TĂNG SĨ SỐ MỖI LỚP LÊN KHOẢNG 20-30 SV
-- LTC001-LTC020: 25 SV/lớp, LTC021-LTC025: 20 SV/lớp
-- ================================================
;WITH CurrentCnt AS (
    SELECT MaLop, COUNT(*) AS cnt
    FROM Diem
    GROUP BY MaLop
),
TargetCnt AS (
    SELECT l.MaLop,
           ISNULL(c.cnt, 0) AS current_cnt,
           CASE 
               WHEN l.MaLop BETWEEN 'LTC001' AND 'LTC020' THEN 25  -- khoảng 20-30, chọn 25
               ELSE 20                                            -- các lớp còn lại ~20
           END AS target_cnt
    FROM LopTinChi l
    LEFT JOIN CurrentCnt c ON l.MaLop = c.MaLop
),
NeedEnroll AS (
    SELECT MaLop,
           target_cnt - current_cnt AS need
    FROM TargetCnt
    WHERE target_cnt > current_cnt
),
Expanded AS (
    SELECT n.MaLop,
           s.MaSV,
           ROW_NUMBER() OVER (PARTITION BY n.MaLop ORDER BY s.MaSV) AS rn
    FROM NeedEnroll n
    CROSS JOIN SinhVien s
    WHERE NOT EXISTS (
        SELECT 1 
        FROM Diem d 
        WHERE d.MaLop = n.MaLop AND d.MaSV = s.MaSV
    )
)
INSERT INTO Diem (MaSV, MaLop, DiemCC, DiemGK, DiemThi, DiemKTHP)
SELECT e.MaSV,
       e.MaLop,
       CAST(ROUND(5 + (ABS(CHECKSUM(NEWID())) % 51) / 10.0, 2) AS DECIMAL(4,2)) AS DiemCC,
       CAST(ROUND(5 + (ABS(CHECKSUM(NEWID())) % 51) / 10.0, 2) AS DECIMAL(4,2)) AS DiemGK,
       CAST(ROUND(5 + (ABS(CHECKSUM(NEWID())) % 51) / 10.0, 2) AS DECIMAL(4,2)) AS DiemThi,
       CAST(ROUND(
            0.3 * (5 + (ABS(CHECKSUM(NEWID())) % 51) / 10.0) +
            0.7 * (5 + (ABS(CHECKSUM(NEWID())) % 51) / 10.0)
       , 2) AS DECIMAL(4,2)) AS DiemKTHP
FROM Expanded e
JOIN NeedEnroll n ON e.MaLop = n.MaLop
WHERE e.rn <= n.need;
GO

PRINT N'✅ Đã tăng sĩ số mỗi lớp tín chỉ lên ~20-25 sinh viên';
GO




-- ================================================
-- 7.1. TỰ ĐỘNG BỔ SUNG PHÂN CÔNG CHO MỖI GIẢNG VIÊN
-- Mục tiêu: mỗi GV có khoảng 5-7 phân công
-- ================================================
;WITH GV_Load AS (
    SELECT g.MaGV,
           COUNT(pc.MaPC) AS current_cnt,
           CASE 
               WHEN COUNT(pc.MaPC) >= 7 THEN COUNT(pc.MaPC)       -- đủ tải
               WHEN COUNT(pc.MaPC) = 0 THEN 6                     -- GV chưa có -> 6 phân công
               WHEN COUNT(pc.MaPC) BETWEEN 1 AND 2 THEN 5         -- ít quá -> nâng lên 5
               ELSE 6                                             -- 3-4 -> nâng lên 6
           END AS target_cnt
    FROM GiangVien g
    LEFT JOIN PhanCongGiangDay pc ON pc.MaGV = g.MaGV
    GROUP BY g.MaGV
),
NeedMore AS (
    SELECT MaGV,
           target_cnt - current_cnt AS need
    FROM GV_Load
    WHERE target_cnt > current_cnt
),
Expanded AS (
    SELECT n.MaGV,
           l.MaLop,
           ROW_NUMBER() OVER (PARTITION BY n.MaGV ORDER BY l.MaLop) AS rn
    FROM NeedMore n
    CROSS JOIN LopTinChi l
    WHERE NOT EXISTS (
        SELECT 1 
        FROM PhanCongGiangDay pc
        WHERE pc.MaGV = n.MaGV AND pc.MaLop = l.MaLop
    )
),
Numbered AS (
    SELECT e.MaGV,
           e.MaLop,
           e.rn,
           ROW_NUMBER() OVER (ORDER BY e.MaGV, e.MaLop) AS global_row
    FROM Expanded e
    JOIN NeedMore n ON e.MaGV = n.MaGV AND e.rn <= n.need
)
INSERT INTO PhanCongGiangDay (MaPC, NgayPC, NgayBatDau, NgayKetThuc, CaHoc, Thu, MaPhong, MaGV, MaLop)
SELECT
    'PC' + RIGHT('000' + CAST(global_row + 20 AS VARCHAR(3)), 3) AS MaPC, -- Bắt đầu từ PC021
    '2025-08-25' AS NgayPC,
    '2025-09-01' AS NgayBatDau,
    '2026-01-16' AS NgayKetThuc,
    (ABS(CHECKSUM(NEWID())) % 5) + 1 AS CaHoc,                -- 1..5
    (ABS(CHECKSUM(NEWID())) % 7) + 2 AS Thu,                  -- 2..8
    (SELECT TOP 1 MaPhong FROM PhongHoc ORDER BY NEWID()) AS MaPhong,
    MaGV,
    MaLop
FROM Numbered;
GO

PRINT N'✅ Đã bổ sung phân công, mỗi giảng viên khoảng 5-7 phân công';
GO

