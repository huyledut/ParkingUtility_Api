pipeline {
    agent any
    stages {
        stage('Build Stage') {
            steps {
                sh 'cd DUTPS.API'
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
        stage("Release Stage") {
            steps {
                sh 'echo "hello"'
            }
        }
        stage('Deploy Stage') {
            steps {
                sh 'echo "hello"'
            }
        }
    }
}
