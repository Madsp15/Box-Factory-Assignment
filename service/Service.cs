using System.Collections.Generic;
using infrastructure;

namespace service;

public class Service
{
    private readonly Repository _repository;

    public Service(Repository repository)
    {
        _repository = repository;
    }


    public Box CreateBox(Box box)
    {
        return _repository.AddBox(box);
    }
    public bool DeleteBox(int boxId)
    {
        return _repository.DeleteBoxById(boxId);
    }
    public Box EditBox(Box box)
    {
        return _repository.UpdateBox(box);
    }
    public IEnumerable<Box> GetAllBoxes()
    {
        return _repository.GetAllBoxes();
    }
    public Box GetBoxById(int boxId)
    {
        return _repository.GetBoxById(boxId);
    }
    public IEnumerable<Box> SearchForBoxByName(string query)
    {
        return _repository.SearchForBoxByName(query);
    }
}