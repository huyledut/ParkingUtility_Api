pipeline {
    agent any
    stages {
        stage('Build Stage') {
            steps {
                sh 'ls'
                sh 'cd DUTPS.API'
                sh 'ls'
                sh 'dotnet build'
                sh 'ls'
                
            }
        }
        stage('Test Stage') {
            steps {
                sh 'cd DUTPS.API/TestingAPI.Test'
                sh 'ls'
                sh 'dotnet test'
            }
        }
        stage("Release Stage and Deploy Stage") {
            steps {
                sh 'echo "hello"'
            }
        }
    }
}
