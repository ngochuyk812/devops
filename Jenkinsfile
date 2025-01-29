def run(String service, String dockerImage, String template, String envDeploy) {
    stage('Build Template') {
        echo "Building project with Docker Image: ${dockerImage} and Template: ${language}, ENV: ${envDeploy}"
        sh """
            cd ${language}/${envDeploy};
            sed -i 's/_SERVICE_NAME_/${service}/g' *;
        """
        
    }
    stage('Deploy') {

        echo "Deploying K8s..."
        sh """
            export KUBECONFIG=/root/devops/k8s-config/admin.config;
            kubectl get nodes;

            cd ${language}/${envDeploy};
            kubectl apply -n ${envDeploy} -f 03.deployment.yaml;
            kubectl get pods -n ${envDeploy};
        """
    }
}
return this