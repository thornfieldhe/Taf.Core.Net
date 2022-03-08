// 何翔华
// Taf.Core.Net.Utility
// PagedAndSortedResultRequestDto.cs

namespace Taf.Core.Net.Utility.Paging;

/// <summary>
/// 默认分页排序查询接口
/// </summary>
[Serializable]
public class PagedAndSortedResultRequestDto : PagedResultRequestDto, IPagedAndSortedResultRequest
{
    public virtual string Sorting{ get; set; }
}

/// <summary>
///     默认查询对象
/// </summary>
public class BaseQueryRequestDto : PagedAndSortedResultRequestDto{
    private string _keyWord;

    public BaseQueryRequestDto() => PageSize = 20;

    public virtual string KeyWord{
        get => _keyWord;
        set => _keyWord = string.IsNullOrWhiteSpace(value)?  null : value.Trim();
    }
}