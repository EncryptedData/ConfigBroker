namespace ConfigBroker.Server.Models.Database;

public enum ConfigValueSource
{
    /// <summary>
    /// Indicates that the value in ConfigBroker is a literal
    /// </summary>
    ConfigBroker,
    
    /// <summary>
    /// Indicates the value is a Azure Key Vault URL
    /// </summary>
    AzureKeyVault,
    
    /// <summary>
    /// Indicates the value is a AWS SecretsManager ARN
    /// </summary>
    AmazonWebServicesSecretsManager,
    
    /// <summary>
    /// Indicates the value is a AWS ParameterStore ARN
    /// </summary>
    AmazonWebServicesParameterStore,
    
    /// <summary>
    /// Indicates the value is a OpenBao URL
    /// </summary>
    OpenBaoSecret,
    
    /// <summary>
    /// Indicates the value is a Hashicorp Vault secret
    /// </summary>
    HashicorpVaultSecret
}