using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Java.Interop;
using Zendesk.Chat;
using Zendesk.Configurations;
using Zendesk.Messaging;
using ZenDeskXamarinBinding.Helpers;

namespace ZenDeskXamarinBinding
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var accountKey = Secrets.accountKey; // your account key; create a secrets.json file at the root of the repo
            var appId = Secrets.appId; // your app id; create a secrets.json file at the root of the repo
            
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Chat.Instance.Init(this, accountKey, appId);
            var configuration = new ChatProvidersConfiguration.Builder().Build();

            Chat.Instance.ChatProvidersConfiguration = configuration;
            var alert = MessagingActivity.Builder()
                .WithEngines(ChatEngine.Engine());
            var config = ChatConfiguration.InvokeBuilder()
                .WithAgentAvailabilityEnabled(true)
                .WithOfflineFormEnabled(true)
                .WithPreChatFormEnabled(true)
                .WithChatMenuActions(ChatMenuAction.EndChat)
                .Build();
            
            alert.Show(this, config
            );
        }
    }
}