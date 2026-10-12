using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho một sự kiện do Câu lạc bộ tổ chức.
/// </summary>
public class Event
{
    public Guid Id { get; private set; }
    public Guid ClubId { get; private set; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public int Capacity { get; private set; }
    public bool IsOnline { get; private set; }

    private Event(Guid id, Guid clubId, string title, DateTime date, int capacity, bool isOnline)
    {
        Id = id;
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
        IsOnline = isOnline;
    }

    /// <summary>
    /// Tạo mới một sự kiện.
    /// </summary>
    public static Event Create(Guid clubId, string title, DateTime date, int capacity, bool isOnline)
    {
        if (clubId == Guid.Empty)
            throw new ArgumentException("ClubId không hợp lệ.", nameof(clubId));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tiêu đề sự kiện không được để trống.", nameof(title));
        if (capacity <= 0)
            throw new ArgumentException("Sức chứa sự kiện phải lớn hơn 0.", nameof(capacity));

        return new Event(Guid.NewGuid(), clubId, title.Trim(), date, capacity, isOnline);
    }

    /// <summary>
    /// Kiểm tra xem sự kiện còn chỗ trống hay không dựa trên số lượng đã đăng ký.
    /// </summary>
    public bool HasCapacity(int registeredCount)
    {
        return registeredCount < Capacity;
    }
}
