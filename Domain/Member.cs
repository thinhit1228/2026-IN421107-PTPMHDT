using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho một thành viên (sinh viên) trong hệ thống EduHub.
/// </summary>
public class Member
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string StudentCode { get; private set; }
    public DateTime JoinedAt { get; private set; }

    private Member(Guid id, string name, string email, string studentCode, DateTime joinedAt)
    {
        Id = id;
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = joinedAt;
    }

    /// <summary>
    /// Tạo mới một thành viên với validation dữ liệu đầu vào.
    /// </summary>
    public static Member Create(string name, string email, string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên thành viên không được để trống.", nameof(name));
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("Email không hợp lệ (phải chứa '@').", nameof(email));
        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException("Mã sinh viên không được để trống.", nameof(studentCode));

        return new Member(Guid.NewGuid(), name.Trim(), email.Trim(), studentCode.Trim(), DateTime.Now);
    }

    /// <summary>
    /// Kiểm tra xem thành viên có đang hoạt động hay không.
    /// </summary>
    public bool IsActive()
    {
        return !string.IsNullOrEmpty(StudentCode);
    }
}