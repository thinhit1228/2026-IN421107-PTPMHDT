using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch01.Domain;

/// <summary>
/// Hình thức điểm danh sự kiện.
/// </summary>
public enum CheckInMethodType
{
    QRCode,
    Manual,
    NFC
}

/// <summary>
/// Đại diện cho bản ghi điểm danh tham gia sự kiện của thành viên.
/// </summary>
public class CheckIn
{
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public CheckInMethodType Method { get; private set; }

    private CheckIn(Guid id, Guid registrationId, DateTime checkedInAt, CheckInMethodType method)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
        Method = method;
    }

    /// <summary>
    /// Tạo mới một bản ghi điểm danh.
    /// </summary>
    public static CheckIn Create(Guid registrationId, CheckInMethodType method)
    {
        if (registrationId == Guid.Empty)
            throw new ArgumentException("RegistrationId không hợp lệ.", nameof(registrationId));

        return new CheckIn(Guid.NewGuid(), registrationId, DateTime.Now, method);
    }

    /// <summary>
    /// Trả về chuỗi mô tả thông tin điểm danh.
    /// </summary>
    public string Summary()
    {
        return $"CheckIn ID: {Id} | Registration ID: {RegistrationId} | Thời gian: {CheckedInAt:yyyy-MM-dd HH:mm:ss} | Hình thức: {Method}";
    }
}