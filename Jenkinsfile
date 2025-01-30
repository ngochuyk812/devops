def run(String service, String dockerImage, String root, String lang, String envDeploy) {
    def forder = "${root}/deploy/${lang}/${envDeploy}";
    stage('Build Template') {
        echo "Building project with Docker Image: ${dockerImage} and Template: ${root}/${lang}, ENV: ${envDeploy}"
        sh """
            if [ ! -d "${forder}" ]; then
                mkdir -p ${forder};
            fi

            cp -rn ${root}/template/${envDeploy}/* ${forder};
            
        """
        script {
            withCredentials([string(credentialsId: 'GithubSecret', variable: 'TOKEN')]) {
                sh "ls"
                sh "cd ${root}"
                sh """
                    git config --global user.email "ci-cd@nnh.com"
                    git config --global user.name "ci-cd"
                    git add .
                    git commit -m "Update template deploy ${DOCKER_NAME_IMAGE}"
                    git push
                """
            }
        }
        sh """
            cd ${forder};
            sed -i 's|_SERVICE_NAME_|${service}|g' *;
            sed -i 's|_IMAGE_|${dockerImage}|g' *;
            sed -i 's|_NAMESPACE_|${envDeploy}|g' *;
        """

        
    }
    stage('Deploy') {

        echo "Deploying K8s..."
        sh """
            export KUBECONFIG=/root/devops/k8s-config/admin.config;
            kubectl get nodes;

            kubectl apply -n ${envDeploy} -f ${root}/secret/docker-hub-secret.yaml

            cd ${forder};
            kubectl apply -n ${envDeploy} -f .;
            kubectl get pods -n ${envDeploy};
        """
    }
}
return this