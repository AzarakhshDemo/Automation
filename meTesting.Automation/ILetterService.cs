
namespace meTesting.Automation;

public interface ILetterService
{
    Letter CreateLetter(Letter inp);
    Letter Get(int id);
    Letter Approve(int id, int userId);
    Letter Sign(int id, int userId);
    Letter Archive(int id, int userId);
    IEnumerable<Letter> GetInbox(int userId);
    Letter Reject(int id, int userId);
}
public class Letter
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Body { get; set; }
    public int ApprovesBy { get; set; }
    public int SignsBy { get; set; }
    public bool IsArchived { get; set; }
    public bool IsApproved { get; set; }
    public bool IsSigned { get; set; }
    public bool IsRejected { get; set; }
    public bool CanArchive => IsApproved && IsSigned;
    public LetterState State { get; set; }
    public string? TransactionId { get; set; }
}

public enum LetterState
{
    Created = 1,
    Approved,
    Signed,
    Rejected
}