FROM microsoft/dotnet:2.1-sdk

WORKDIR /app

RUN  apt-get update \
  && apt-get install -y jq \
  && rm -rf /var/lib/apt/lists/*
RUN wget https://raw.githubusercontent.com/vishnubob/wait-for-it/8ed92e8cab83cfed76ff012ed4a36cef74b28096/wait-for-it.sh
RUN chmod +x wait-for-it.sh

COPY tests.csproj .
RUN dotnet restore tests.csproj
COPY . .
RUN dotnet build -c Release

ENTRYPOINT ["./run_test.sh"]