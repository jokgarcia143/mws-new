window.onload = function () {
    document.getElementById("pdfGenerate")
        .addEventListener("click", () => {
            const invoice = this.document.getElementById("disconnection-receive")
            const title = this.document.getElementById("spn-title")
            console.log(invoice);
            console.log(window);
            var opt = {
                html2canvas: {
                    dpi: 96,
                    scale: 4,
                    letterRendering: true,
                    useCORS: true
                },
                pagebreak: { mode: 'avoid-all', before: '#page2el' },
                margin: 0.1,
                filename: title.innerHTML + '.pdf',
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