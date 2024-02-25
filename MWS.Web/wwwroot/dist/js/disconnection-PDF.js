
window.onload = function () {

    //const getFirst10PagesHTML = () => {
    //    const pagesContainer = document.createElement('div');

    //    for (let i = 1; i <= 10; i++) {
    //        const pageElement = document.getElementById(`disconnection-notices{i}`);

    //        if (pageElement) {
    //            const clonedPage = pageElement.cloneNode(true);
    //            pagesContainer.appendChild(clonedPage);
    //        }
    //    }

    //    return pagesContainer.innerHTML;
    //};

    // Get the HTML content for the first 10 pages
    /*const htmlContent = getFirst10PagesHTML();*/

    document.getElementById("pdfGenerate")
        .addEventListener("click", () => {
            const invoice = this.document.getElementById("disconnection-notices")
            console.log(invoice);
            console.log(window);
            var opt = {
                html2canvas: {
                    dpi: 96,
                    scale: 4,
                    letterRendering: true,
                    useCORS: true
                },
                margin: 0.1,
                filename: 'DisconnectionNotice.pdf',
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