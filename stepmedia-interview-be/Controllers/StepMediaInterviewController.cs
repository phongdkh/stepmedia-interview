using Microsoft.AspNetCore.Mvc;

namespace stepmedia_interview_be.Controllers;

[ApiController]
[Route("stepmedia-interview")]
public class StepMediaInterviewController : ControllerBase
{
    private const int NUMBER_TO_SORT = 10;

    public StepMediaInterviewController()
    {
    }

    [HttpPost(Name = "sort-array")]
    public ActionResult SortArray([FromBody] string array)
    {
        if (string.IsNullOrEmpty(array))
            return BadRequest("Input cannot null or empty");
        var sort = array.Split(",").OrderByDescending(_=> _);
        if (sort is null || !sort.Any())
            return BadRequest("The input must contains comma");
        if (sort.Count() < NUMBER_TO_SORT*3)
            return BadRequest("The string required greater than 30 items");
        var firstTopItems = sort.Skip(0).Take(NUMBER_TO_SORT);
        var secondTopItems = sort.Skip(1*NUMBER_TO_SORT).Take(NUMBER_TO_SORT);
        var thirdTopItems = sort.Skip(2*NUMBER_TO_SORT).Take(NUMBER_TO_SORT);
        var remainingItems = sort.Skip(3 * NUMBER_TO_SORT).Take(int.MaxValue);
        var firstSeparate = remainingItems.Skip(0).Take(remainingItems.Count() / 2);
        var secondSeparate = remainingItems.Skip(remainingItems.Count() / 2).Take(remainingItems.Count() / 2);
        return Ok($"{string.Join(",",secondTopItems)}" +
                  $" >> {string.Join(",",firstSeparate)}" +
                  $" >> {string.Join(",",firstTopItems)}" +
                  $" >> {string.Join(",",secondSeparate)}" +
                  $" >> {string.Join(",",thirdTopItems)}");
    }
}
