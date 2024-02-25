let scripts = document.getElementsByTagName('script');
let script = scripts[scripts.length - 1];

for (let i = 0, len = scripts.length; i < len; i++) {
    var src = scripts[i].getAttribute('src').split('?');
    var url = src[0];
    var args = src[1];

    if (!args) {
        continue;
    }
}

const date = new Date();

window.onload = function () {
    document.getElementById("pdfGenerate")
        .addEventListener("click", () => {
            const invoice = this.document.getElementById("table")
            console.log(invoice);
            console.log(window);
            var opt = {
                margin: 0.5,
                filename: args.concat(' ', date.getMonth(), '-', date.getDate(), '-', date.getFullYear()),
                image: { type: 'jpeg', quality: 1 },
                jsPDF: { unit: 'in', format: [8.5, 11], orientation: 'portrait' }
            };
            html2pdf().from(invoice).set(opt).save();
        })
    document.getElementById("pdfGenerate").click();
}

function myAlert() {
    alert("PDF Sucessfuly Generated!");
}