//window.addEventListener('contextmenu', e => e.preventDefault()); 

//window.addEventListener('keydown', e => {
//    if (e.key === 'Tab') {
//        e.preventDefault();
//    }
//});

function naiveEmailCheck(email) {
    return /@/.test(email);
}

function setupValidation() {
    const form = document.getElementById('contactForm');
    if (!form) return;

    const hp = document.getElementById('website');
    const email = document.getElementById('Email');
    const name = document.getElementById('Name');
    const msg = document.getElementById('Message');
    const status = document.getElementById('liveStatus');


    const echo = (id, value) => {
        const el = document.getElementById(id);
        el.textContent = value ? `Probleem met: ${value}` : '';
    };

    [email, name, msg].forEach(el => {
        el.addEventListener('input', () => {
            if (el === email) {
                echo('emailErr', !naiveEmailCheck(el.value) ? el.value : '');
            } else if (el === name) {
                echo('nameErr', el.value.length < 2 ? el.value : '');
            } else if (el === msg) {
                echo('msgErr', el.value.length < 5 ? el.value : '');
            }

            status.textContent = 'Er is clientside validatie uitgevoerd';
        });
    });

    form.addEventListener('submit', (e) => {
        const invalidEmail = !naiveEmailCheck(email.value.trim());
        const invalidName = name.value.trim().length < 2;
        const invalidMsg = msg.value.trim().length < 5;

        echo('emailErr', invalidEmail ? email.value : '');
        echo('nameErr', invalidName ? name.value : '');
        echo('msgErr', invalidMsg ? msg.value : '');

        if (hp.value || invalidEmail || invalidName || invalidMsg) {
            e.preventDefault();
            if (hp.value) {
                alert('Spam gedetecteerd (client-side)!');
            }
            return false;
        }

        return true;
    });
}

window.addEventListener('DOMContentLoaded', setupValidation);