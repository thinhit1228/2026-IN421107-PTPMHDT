using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch01.Domain;

/// <summary>
/// Trạng thái của phiếu đăng ký sự kiện.
/// </summary>
public enum RegistrationStatus
{
    Pending,
    Confirmed,
    Cancelled
}

/// <summary>
/// Đại diện cho phiếu đăng ký tham gia sự kiện của thành viên.
/// </summary>
public class Registration
{
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public RegistrationStatus Status { get; private set; }

    private Registration(Guid id, Guid memberId, Guid eventId, DateTime registeredAt, RegistrationStatus status)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = status;
    }

    /// <summary>
    /// Tạo mới một phiếu đăng ký ở trạng thái Pending.
    /// </summary>
    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty || eventId == Guid.Empty)
            throw new ArgumentException("MemberId hoặc EventId không hợp lệ.");

        return new Registration(Guid.NewGuid(), memberId, eventId, DateTime.Now, RegistrationStatus.Pending);
    }

    /// <summary>
    /// Xác nhận phiếu đăng ký.
    /// </summary>
    public void Confirm()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException("Không thể xác nhận phiếu đăng ký đã bị hủy.");
        if (Status == RegistrationStatus.Confirmed)
            throw new InvalidOperationException("Phiếu đăng ký này đã được xác nhận trước đó.");

        Status = RegistrationStatus.Confirmed;
    }

    /// <summary>
    /// Hủy phiếu đăng ký.
    /// </summary>
    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException("Phiếu đăng ký đã ở trạng thái hủy.");

        Status = RegistrationStatus.Cancelled;
    }
}