# User Stories - Quản lý Câu lạc bộ & Sự kiện (EduHub)

## 1. Sinh viên: Rời khỏi CLB
- **Vai trò:** Sinh viên
- **Mô tả:** As a Student, I want to leave a club so that I am no longer listed as a member.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Đang là thành viên → chọn rời CLB → xóa khỏi danh sách thành viên (`Club.Members`).
  - ② Chưa là thành viên → yêu cầu rời → báo lỗi “Không phải thành viên”.

## 2. Sinh viên: Hủy đăng ký sự kiện
- **Vai trò:** Sinh viên
- **Mô tả:** As a Student, I want to cancel my event registration so that my slot is freed up.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Có phiếu đăng ký đang hoạt động → hủy đăng ký → cập nhật trạng thái `Registration.Status = Cancelled`.
  - ② Chưa đăng ký → chọn hủy → báo lỗi “Chưa đăng ký sự kiện”.

## 3. Ban CLB: Duyệt thành viên đăng ký
- **Vai trò:** Ban CLB
- **Mô tả:** As a Club Board, I want to review and approve member requests so that new members can join.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Có yêu cầu tham gia hợp lệ → duyệt → thêm thành viên vào danh sách CLB (`Club.AddMember`).
  - ② Yêu cầu không hợp lệ → duyệt → báo lỗi ngoại lệ.

## 4. Ban CLB: Chỉnh sửa thông tin sự kiện
- **Vai trò:** Ban CLB
- **Mô tả:** As a Club Board, I want to edit event details so that participants have up-to-date information.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① Sự kiện chưa diễn ra (`Event.Date > DateTime.Now`) → chỉnh sửa → cập nhật thông tin thành công.
  - ② Sự kiện đã diễn ra → chỉnh sửa → báo lỗi “Không thể chỉnh sửa”.

## 5. Admin: Khóa một CLB
- **Vai trò:** Admin
- **Mô tả:** As an Admin, I want to lock an inactive or violating club so that its activities are suspended.
- **Tiêu chuẩn nghiệm thu (AC):**
  - ① CLB đang hoạt động (`IsActive = true`) → khóa → chuyển trạng thái `IsActive = false`.
  - ② CLB đã bị khóa → khóa lại → báo lỗi “CLB đã bị khóa”.