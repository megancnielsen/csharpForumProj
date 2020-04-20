using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumDemo.Models;
using ForumDemo;

public class PostsController : Controller
{
    private ForumContext db;
    
    // controller constructor overload
    public PostsController(ForumContext context)
    {
        db = context;
    }


    [HttpGet("/Posts/All")] //name_of_controller/name_of_action
    public IActionResult All()
    {

        List<Post> allPosts = db.Posts.ToList();

        return View(allPosts);
    }

    [HttpGet("/Posts/New")]
    public IActionResult New()
    {
        return View();
    }
    
    [HttpPost("/Posts/Create")]
    public IActionResult Create(Post newPost)
    {
       if (ModelState.IsValid == false)
       {
           // to display validation error messages
           return View("New");
       }

        // ModelState IS valid
        db.Posts.Add(newPost);
        // after SaveChanges, newPost object gets its id from the database
        db.SaveChanges();
        return RedirectToAction("Details", new { id = newPost.PostId });
    }
    
    [HttpGet("/Posts/{id}")]
    public IActionResult Details(int id)
    {
        Post selectedPost = db.Posts.FirstOrDefault(post => post.PostId == id);

        // in case user manually types invalid ID into the URL
        if (selectedPost == null)
        {
            RedirectToAction("All");
        }

        return View(selectedPost);
    }

    [HttpGet("/Posts/{id}/Edit")]
    public IActionResult Edit(int id)
    {
        Post postToEdit = db.Posts.FirstOrDefault(post => post.PostId == id);

        if  (postToEdit == null)
        {
            return RedirectToAction("All");
        }

        return View(postToEdit);
    }

    [HttpPost("/Posts/Update")]
    public IActionResult Update(Post editedPost, int id)
    {
        if (ModelState.IsValid == false)
        {
            // so error messages will be displayed and original input box values prefilled
            return View("Edit", editedPost);
        }

        Post dbPost = db.Posts.FirstOrDefault(post => post.PostId == id);

        if (dbPost == null)
        {
            return RedirectToAction("All");
        }

        dbPost.Topic = editedPost.Topic;
        dbPost.Body = editedPost.Body;
        dbPost.UpdatedAt = DateTime.Now;

        db.Posts.Update(dbPost);
        db.SaveChanges();

        return RedirectToAction("Details", new { id = dbPost.PostId });
    }

    [HttpGet("/Posts/{id}/Delete")]
    public IActionResult Delete(int id)
    {
        Post postToDelete = db.Posts.FirstOrDefault(post => post.PostId == id);
        db.Posts.Remove(postToDelete);
        db.SaveChanges();

        return RedirectToAction("All");
    }
}