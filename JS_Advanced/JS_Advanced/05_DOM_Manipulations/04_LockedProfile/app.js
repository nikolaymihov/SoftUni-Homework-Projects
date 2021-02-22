function lockedProfile() {
    const profiles = Array.from(document.getElementsByClassName('profile'));
    
    profiles.forEach(profile => {
        profile.addEventListener('click', function (event) {
            const elements = profile.children;

            if (elements[4].checked && event.target === elements[10]) {
                if (elements[9].style.display === 'block') {
                    elements[9].style.display = 'none';
                    elements[10].textContent = 'Show more';
                }
                else {
                    elements[9].style.display = 'block';
                    elements[10].textContent = 'Hide it';
                }
            }

        });
    });
}