# $env:VIRTUAL_ENV_DISABLE_PROMPT = 1
oh-my-posh init pwsh --config "~/.config/poshthemes/theme.omp.json" | invoke-expression
Set-PSReadLineOption -PredictionViewStyle ListView