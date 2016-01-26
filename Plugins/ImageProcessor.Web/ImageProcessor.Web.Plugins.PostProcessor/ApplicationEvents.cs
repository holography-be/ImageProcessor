﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationEvents.cs" company="James South">
//   Copyright (c) James South.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Defines the ApplicationEvents type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web;

[assembly: PreApplicationStartMethod(typeof(ImageProcessor.Web.Plugins.PostProcessor.ApplicationEvents), "Start")]

namespace ImageProcessor.Web.Plugins.PostProcessor
{
    using System.IO;

    using ImageProcessor.Web.Helpers;
    using ImageProcessor.Web.HttpModules;

    /// <summary>
    /// Binds the PostProcessor to process any image requests within the web application.
    /// Many thanks to Azure Image Optimizer <see href="https://github.com/ligershark/AzureJobs"/>
    /// </summary>
    public static class ApplicationEvents
    {
        /// <summary>
        /// The initial startup method.
        /// </summary>
        public static void Start()
        {
            ImageProcessingModule.OnPostProcessing += PostProcess;
        }

        /// <summary>
        /// Asynchronously post-processes cached images.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// An <see cref="PostProcessingEventArgs">EventArgs</see> that contains the event data.
        /// </param>
        private static void PostProcess(object sender, PostProcessingEventArgs e)
        {
            e.ImageStream = PostProcessor.PostProcessImage(e.ImageStream, e.ImageExtension);
        }
    }
}
