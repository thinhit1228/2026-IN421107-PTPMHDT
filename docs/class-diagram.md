# Sơ đồ lớp (Class Diagram) - EduHub

```mermaid
classDiagram
    class Member {
        +Guid Id
        +string Name
        +string Email
        +string StudentCode
        +DateTime JoinedAt
        +Create(name, email, studentCode) Member
        +bool IsActive()
    }

    class Club {
        +Guid Id
        +string Name
        +string Description
        +DateTime CreatedAt
        +List~Member~ Members
        +Create(name, description) Club
        +void AddMember(Member member)
        +int MemberCount()
        +void RemoveMember(Guid memberId)
        +void LockClub()
    }

    class Event {
        +Guid Id
        +Guid ClubId
        +string Title
        +DateTime Date
        +int Capacity
        +bool IsOnline
        +Create(clubId, title, date, capacity, isOnline) Event
        +bool HasCapacity(int registeredCount)
        +void UpdateDetails(string newTitle, DateTime newDate)
    }

    class Registration {
        +Guid Id
        +Guid MemberId
        +Guid EventId
        +DateTime RegisteredAt
        +string Status
        +Create(memberId, eventId) Registration
        +void Confirm()
        +void Cancel()
    }

    class CheckIn {
        +Guid Id
        +Guid RegistrationId
        +DateTime CheckedInAt
        +string Method
        +Create(registrationId, method) CheckIn
        +string Summary()
    }

    Club "1" -- "0..*" Member : has members
    Club "1" -- "0..*" Event : organizes
    Event "1" -- "0..*" Registration : contains
    Member "1" -- "0..*" Registration : registers
    Registration "1" -- "0..1" CheckIn : verified by