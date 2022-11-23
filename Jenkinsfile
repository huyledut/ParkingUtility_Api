pipeline {
    agent any
    stages {
        stage('Build Stage') {
            steps {
                sh 'cd DUTPS.API'
                sh 'dotnet build'
                sh 'ls'
                sh 'cd ../'
            }
        }
        stage('Test Stage') {
            steps {
                sh 'echo "hello"'
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