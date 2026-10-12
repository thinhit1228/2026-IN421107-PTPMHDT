using System;
using EduHub.Ch01.Domain;

// Thiết lập mã hóa hiển thị tiếng Việt chuẩn trên Console
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Định nghĩa hằng số phân cách để tái sử dụng, tránh lặp lại chuỗi cố định
const string MainSeparator = "==========================================================";
const string StepSeparator = "----------------------------------------------------------";

Console.WriteLine(MainSeparator);
Console.WriteLine("            EDUHUB - CHƯƠNG TRÌNH CONSOLE APP DEMO        ");
Console.WriteLine(MainSeparator);
Console.WriteLine();

try
{
    // BƯỚC 1: Tạo CLB "Tech Club" với mô tả phù hợp
    Console.WriteLine(StepSeparator);
    Console.WriteLine("BƯỚC 1: Tạo CLB 'Tech Club'");
    Console.WriteLine(StepSeparator);
    var techClub = Club.Create("Tech Club", "Câu lạc bộ Công nghệ thông tin trường Đại học Đồng Tháp");
    Console.WriteLine($"+ Tên CLB     : {techClub.Name}");
    Console.WriteLine($"+ Mô tả       : {techClub.Description}");
    Console.WriteLine($"+ Ngày tạo    : {techClub.CreatedAt:yyyy-MM-dd HH:mm:ss}");
    Console.WriteLine();

    // BƯỚC 2: Thêm 3 thành viên vào CLB (dữ liệu mẫu tự tạo)
    Console.WriteLine(StepSeparator);
    Console.WriteLine("BƯỚC 2: Thêm 3 thành viên vào CLB");
    Console.WriteLine(StepSeparator);
    var member1 = Member.Create("Nguyễn Văn An", "an.nv@student.dthu.edu.vn", "SV2026001");
    var member2 = Member.Create("Trần Thị Bình", "binh.tt@student.dthu.edu.vn", "SV2026002");
    var member3 = Member.Create("Lê Hoàng Cường", "cuong.lh@student.dthu.edu.vn", "SV2026003");

    techClub.AddMember(member1);
    techClub.AddMember(member2);
    techClub.AddMember(member3);

    Console.WriteLine($"+ Đã thêm thành công 3 thành viên vào '{techClub.Name}':");
    Console.WriteLine($"  1. {member1.Name} - MSSV: {member1.StudentCode} ({member1.Email})");
    Console.WriteLine($"  2. {member2.Name} - MSSV: {member2.StudentCode} ({member2.Email})");
    Console.WriteLine($"  3. {member3.Name} - MSSV: {member3.StudentCode} ({member3.Email})");
    Console.WriteLine($"+ Tổng số thành viên CLB hiện tại: {techClub.MemberCount()}");
    Console.WriteLine();

    // BƯỚC 3: Tạo 1 sự kiện cho CLB (Workshop AI, capacity = 50)
    Console.WriteLine(StepSeparator);
    Console.WriteLine("BƯỚC 3: Tạo sự kiện cho CLB");
    Console.WriteLine(StepSeparator);
    var eventDate = DateTime.Now.AddDays(7);
    var workshopEvent = Event.Create(techClub.Id, "Workshop AI & Ứng dụng Thực tế", eventDate, 50, true);

    Console.WriteLine($"+ Tên sự kiện : {workshopEvent.Title}");
    Console.WriteLine($"+ Thời gian   : {workshopEvent.Date:yyyy-MM-dd HH:mm}");
    Console.WriteLine($"+ Sức chứa    : {workshopEvent.Capacity} người");
    Console.WriteLine($"+ Hình thức   : {(workshopEvent.IsOnline ? "Trực tuyến (Online)" : "Trực tiếp")}");
    Console.WriteLine();

    // BƯỚC 4: 2 thành viên đăng ký tham gia sự kiện -> Status = "Pending" -> gọi Confirm()
    Console.WriteLine(StepSeparator);
    Console.WriteLine("BƯỚC 4: Đăng ký tham gia sự kiện và xác nhận");
    Console.WriteLine(StepSeparator);
    var reg1 = Registration.Create(member1.Id, workshopEvent.Id);
    var reg2 = Registration.Create(member2.Id, workshopEvent.Id);

    Console.WriteLine($"- Thành viên {member1.Name} đăng ký. Trạng thái ban đầu: {reg1.Status}");
    Console.WriteLine($"- Thành viên {member2.Name} đăng ký. Trạng thái ban đầu: {reg2.Status}");

    // Gọi phương thức Confirm()
    reg1.Confirm();
    reg2.Confirm();
    Console.WriteLine($"> Sau khi gọi phương thức Confirm():");
    Console.WriteLine($"  + Phiếu của {member1.Name}: {reg1.Status}");
    Console.WriteLine($"  + Phiếu của {member2.Name}: {reg2.Status}");
    Console.WriteLine();

    // BƯỚC 5: 1 thành viên thực hiện check-in -> tạo CheckIn record
    Console.WriteLine(StepSeparator);
    Console.WriteLine("BƯỚC 5: Thực hiện Check-in sự kiện");
    Console.WriteLine(StepSeparator);
    var checkInRecord = CheckIn.Create(reg1.Id, CheckInMethodType.QRCode);
    Console.WriteLine($"+ Thành viên {member1.Name} đã thực hiện quét mã check-in.");
    Console.WriteLine($"  Chi tiết bản ghi: {checkInRecord.Summary()}");
    Console.WriteLine();

    // BƯỚC 6: In báo cáo tham dự: số đăng ký, số check-in, danh sách tên
    Console.WriteLine(StepSeparator);
    Console.WriteLine("BƯỚC 6: Báo cáo tham dự sự kiện");
    Console.WriteLine(StepSeparator);
    Console.WriteLine($"[BÁO CÁO CHI TIẾT] Sự kiện: {workshopEvent.Title}");
    Console.WriteLine($"  - Tổng số lượng đăng ký : 2");
    Console.WriteLine($"  - Tổng số lượng check-in : 1");
    Console.WriteLine($"  - Danh sách tên thành viên tham dự:");
    Console.WriteLine($"    1. {member1.Name} (MSSV: {member1.StudentCode}) - Đã check-in");
    Console.WriteLine($"    2. {member2.Name} (MSSV: {member2.StudentCode}) - Chưa check-in");
    Console.WriteLine();

    // BƯỚC 7: Thử một thao tác vi phạm luật nghiệp vụ (Confirm() phiếu đã huỷ) và bắt InvalidOperationException
    Console.WriteLine(StepSeparator);
    Console.WriteLine("BƯỚC 7: Kiểm thử ngoại lệ (Vi phạm quy tắc nghiệp vụ)");
    Console.WriteLine(StepSeparator);
    var reg3 = Registration.Create(member3.Id, workshopEvent.Id);
    reg3.Cancel();
    Console.WriteLine($"- Thành viên {member3.Name} đã hủy phiếu đăng ký. Trạng thái: {reg3.Status}");
    Console.WriteLine($"- Cố tình gọi phương thức Confirm() trên phiếu đã hủy của {member3.Name}...");

    reg3.Confirm(); // Dòng này sẽ kích hoạt ngoại lệ InvalidOperationException
}
catch (InvalidOperationException ex)
{
    Console.WriteLine();
    Console.WriteLine($"[BẮT NGOẠI LỆ NGHIỆP VỤ THÀNH CÔNG]: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine($"[LỖI HỆ THỐNG]: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine(MainSeparator);
Console.WriteLine("             CHƯƠNG TRÌNH DEMO CHẠY THÀNH CÔNG XONG           ");
Console.WriteLine(MainSeparator);