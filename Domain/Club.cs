using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho một câu lạc bộ sinh viên.
/// </summary>
public class Club
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<Member> _members = new();
    public IReadOnlyCollection<Member> Members => _members.AsReadOnly();

    private Club(Guid id, string name, string description, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    /// <summary>
    /// Tạo mới một Câu lạc bộ.
    /// </summary>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên CLB không được để trống.", nameof(name));

        return new Club(Guid.NewGuid(), name.Trim(), description?.Trim() ?? string.Empty, DateTime.Now);
    }

    /// <summary>
    /// Thêm một thành viên vào CLB.
    /// </summary>
    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);
        if (_members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException("Thành viên này đã có trong danh sách CLB.");

        _members.Add(member);
    }

    /// <summary>
    /// Trả về số lượng thành viên hiện tại của CLB.
    /// </summary>
    public int MemberCount()
    {
        return _members.Count;
    }
}
