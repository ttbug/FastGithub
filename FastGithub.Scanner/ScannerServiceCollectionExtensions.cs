﻿using FastGithub.Scanner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastGithub
{
    /// <summary>
    /// 服务注册扩展
    /// </summary>
    public static class ScannerServiceCollectionExtensions
    {
        /// <summary>
        /// 注册程序集下所有服务下选项
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration">配置</param>  
        /// <returns></returns>
        public static IServiceCollection AddGithubScanner(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(ScannerServiceCollectionExtensions).Assembly;
            return services 
                .AddServiceAndOptions(assembly, configuration)
                .AddHostedService<GithubFullScanHostedService>()
                .AddHostedService<GithubResultScanHostedService>()
                .AddSingleton<IGithubScanResults>(appService => appService.GetRequiredService<GithubContextCollection>());
            ;
        }
    }
}