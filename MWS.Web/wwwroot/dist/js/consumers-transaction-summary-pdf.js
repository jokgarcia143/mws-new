window.onload = function () {
    document.getElementById("pdfGenerate")
        .addEventListener("click", () => {
            const invoice = this.document.getElementById("consumer-summary")
            console.log(invoice);
            console.log(window);
            var opt = {
                margin: 0.2,
                filename: 'Consumers-Transaction-Summary.pdf',
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