def run(String dockerImage, String language) {
    stage('Build Template') {
        echo "Building project with Docker Image: ${dockerImage} and Language: ${language}"
        sh """
            cd ${language};
            ls -la;
        """
        
    }
    stage('Deploy') {

        echo "Deploying K8s..."
        sh """
            export KUBECONFIG=/root/devops/k8s-config/admin.config;
            kubectl get nodes;
        """
    }
}
return this