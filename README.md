<h2> What is this ?</h2>
<p>
A simple library to send push notification by FastFirebase
</p>
<h2> Install via NuGet</h2>
To install FastFirebase, run the following command in the Package Manager Console
<pre lang="code">
<code>
    pm> Install-Package FastFirebase
</code>
</pre>
<p>You can also view the <a href="https://www.nuget.org/packages/FastFirebase" rel="nofollow">package page</a> on NuGet.</p>
<h2>How to use ?</h2>

1- Install package from nuget

2- Add required services Startup class as below :
<pre lang="code">
<code>
 services.AddFirebase(options=>
          {
             options.ServerKey = "FIREBASE_SERVER_KEY";
          });
</code>
</pre>
3- Send push notification by using IPushService:
<p>

</p>
<pre lang="code">
<code>
      var serviceProvider = GetServiceProvider();
      var pushService = serviceProvider.GetRequiredService<IPushService>();

      var model = new PushJsonModel
      {
          deviceTokens = new string[] { "DeviceToken1", "DeviceToken2" },
          title = "test",
          body = "this is a test",
          data = null
      };
      await pushService.SendPushAsync(model);
</code>
</pre>
