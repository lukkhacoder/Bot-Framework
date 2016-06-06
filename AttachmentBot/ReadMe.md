Using properties of `Attachment` class in the `Microsoft.Bot.Connector` namespace, it very easy to send messages with rich content such as images and attachments back to the user.

## Attachment class
The `Attachment` class contains properties can that can be used to send rich content back to the user. The class definition is listed below
```language-csharp
    public class Attachment
    {       
        public IList<Action> Actions { get; set; }
        public object Content { get; set; }
        public string ContentType { get; set; }
        public string ContentUrl { get; set; }
        public string FallbackText { get; set; }
        public string Text { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string TitleLink { get; set; }
    }
```
### ContentType and ContentUrl
The primary way of sending back rich information is by setting values of the `ContentType` and `ContentUrl` properties. 

* **ContentType**: This should be set to the mime type of the content that is available at the ContentUrl location.
* **ContentUrl**: This should be set to the link of the actual content such as an image, video or a document.

Read the rest of the post on my blog at [How to use attachments to send rich content to user using #botframework](http://lukkhacoder.com/2016/06/06/how-to-use-attachments-to-send-rich-content-to-users-using-botframework/)
