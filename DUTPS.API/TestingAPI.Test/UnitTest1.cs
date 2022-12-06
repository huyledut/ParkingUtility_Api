using DUTPS.API.Dtos.Authentication;
using DUTPS.API.Services;
using DUTPS.Commons;
using DUTPS.Databases;
using Microsoft.EntityFrameworkCore;

namespace TestingAPI.Test;

public class UnitTest1
{
  [Fact]
  public void Test1()
  {
    Assert.True(true);
  }

  [Fact]
  public void Test2()
  {
    var paging = new Paging(31, 2, 10);
    if (paging.Limit == 10 && paging.Total == 31 && paging.Page == 2 && paging.TotalPages == 4)
    {
      Assert.True(true);

    }
    else
    {
      Assert.False(true);
    }
  }

  [Fact]
  public void Test3()
  {
    var login = new UserLoginDto();
    if (login.Username == null || login.Password == null)
    {
      Assert.True(true);
    }
    else
    {
      Assert.False(true);
    }
  }
}
