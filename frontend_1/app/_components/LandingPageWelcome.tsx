'use client';
import React, { useState } from 'react';
import { CheckCircle, Rocket, ShieldCheck, Zap, BarChart3, Smartphone, ArrowRight, Menu, X } from 'lucide-react';

const LandingPageWelcome = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  return (
    <div className="min-h-screen bg-slate-50 text-slate-900 font-sans">
      {/* --- NAVIGATION --- */}
      <nav className="bg-white border-b border-slate-200 sticky top-0 z-50">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16 items-center">
            <div className="flex items-center gap-2">
              <div className="bg-blue-600 p-1.5 rounded-lg">
                <Rocket className="text-white w-6 h-6" />
              </div>
              <span className="text-xl font-bold tracking-tight">Rifa<span className="text-blue-600">Pro</span></span>
            </div>
            
            <div className="hidden md:flex items-center gap-8 text-sm font-medium text-slate-600">
              <a href="#funcionalidades" className="hover:text-blue-600 transition">Funcionalidades</a>
              <a href="#como-funciona" className="hover:text-blue-600 transition">Como Funciona</a>
              <a href="#precos" className="hover:text-blue-600 transition">Preços</a>
              <a href='/auth' className="bg-blue-600 text-white px-5 py-2 rounded-full hover:bg-blue-700 transition shadow-md shadow-blue-200">
                Começar Agora
              </a>
            </div>

            <button className="md:hidden" onClick={() => setIsMenuOpen(!isMenuOpen)}>
              {isMenuOpen ? <X /> : <Menu />}
            </button>
          </div>
        </div>
      </nav>

      {/* --- HERO SECTION --- */}
      <section className="pt-16 pb-24 px-4 bg-gradient-to-b from-white to-slate-50">
        <div className="max-w-5xl mx-auto text-center">
          <div className="inline-flex items-center gap-2 bg-blue-50 text-blue-700 px-4 py-1.5 rounded-full text-sm font-semibold mb-6 animate-fade-in">
            <Zap size={16} />
            <span>A plataforma nº 1 para sorteios automáticos</span>
          </div>
          <h1 className="text-4xl md:text-6xl font-extrabold tracking-tight mb-6">
            Crie, venda e gerencie suas <span className="text-blue-600">rifas online</span> em minutos
          </h1>
          <p className="text-lg md:text-xl text-slate-600 mb-10 max-w-2xl mx-auto">
            A solução completa para você lucrar com sorteios de forma segura, automatizada e 100% profissional. Sem complicação com planilhas ou papel.
          </p>
          <div className="flex flex-col sm:flex-row justify-center gap-4">
            <a href='/raffle/create' className="bg-blue-600 text-white px-8 py-4 rounded-xl font-bold text-lg hover:bg-blue-700 transition flex items-center justify-center gap-2 shadow-xl shadow-blue-200">
              Criar minha rifa agora <ArrowRight size={20} />
            </a>
            <button className="bg-white border border-slate-200 text-slate-700 px-8 py-4 rounded-xl font-bold text-lg hover:bg-slate-50 transition">
              Ver demonstração
            </button>
          </div>
          <div className="mt-12 flex flex-wrap justify-center gap-6 text-sm text-slate-500 italic">
            <span className="flex items-center gap-1"><CheckCircle size={16} className="text-green-500" /> Pagamento via Pix</span>
            <span className="flex items-center gap-1"><CheckCircle size={16} className="text-green-500" /> Sorteio Automatizado</span>
            <span className="flex items-center gap-1"><CheckCircle size={16} className="text-green-500" /> Suporte 24h</span>
          </div>
        </div>
      </section>

      {/* --- FEATURES --- */}
      <section id="funcionalidades" className="py-24 px-4">
        <div className="max-w-7xl mx-auto">
          <div className="text-center mb-16">
            <h2 className="text-3xl font-bold mb-4">Tudo o que você precisa para vender mais</h2>
            <p className="text-slate-600">Desenvolvemos as ferramentas certas para o seu sucesso.</p>
          </div>
          
          <div className="grid md:grid-cols-3 gap-8 text-left">
            {[
              { 
                icon: <Zap className="text-blue-600" />, 
                title: "Pagamento Instantâneo", 
                desc: "Integração nativa com Pix. O número é liberado automaticamente após a confirmação do pagamento." 
              },
              { 
                icon: <Smartphone className="text-blue-600" />, 
                title: "Interface Mobile First", 
                desc: "Sua página de rifa otimizada para compras rápidas diretamente pelo WhatsApp e Instagram." 
              },
              { 
                icon: <BarChart3 className="text-blue-600" />, 
                title: "Dashboard Completo", 
                desc: "Acompanhe suas vendas, cliques e lucros em tempo real com gráficos e relatórios detalhados." 
              },
              { 
                icon: <ShieldCheck className="text-blue-600" />, 
                title: "Segurança Jurídica", 
                desc: "Termos de uso prontos e integração com sorteios da Loteria Federal para total transparência." 
              },
              { 
                icon: <Rocket className="text-blue-600" />, 
                title: "Cotas Premiadas", 
                desc: "Crie gatilhos de venda rápida com números premiados escondidos entre as cotas." 
              },
              { 
                icon: <CheckCircle className="text-blue-600" />, 
                title: "Recuperação de Carrinho", 
                desc: "Aviso automático para clientes que reservaram mas não pagaram, aumentando sua conversão." 
              }
            ].map((feature, idx) => (
              <div key={idx} className="bg-white p-8 rounded-2xl border border-slate-100 shadow-sm hover:shadow-md transition">
                <div className="mb-4 bg-blue-50 w-12 h-12 flex items-center justify-center rounded-lg italic">
                  {feature.icon}
                </div>
                <h3 className="text-xl font-bold mb-2">{feature.title}</h3>
                <p className="text-slate-600 leading-relaxed">{feature.desc}</p>
              </div>
            ))}
          </div>
        </div>
      </section>

      {/* --- SOCIAL PROOF / STATS --- */}
      <section className="bg-blue-600 py-16 px-4 text-white">
        <div className="max-w-7xl mx-auto grid md:grid-cols-3 gap-12 text-center">
          <div>
            <div className="text-4xl font-extrabold mb-2">+R$ 2M</div>
            <div className="text-blue-100 uppercase tracking-widest text-sm">Movimentados</div>
          </div>
          <div>
            <div className="text-4xl font-extrabold mb-2">5.000+</div>
            <div className="text-blue-100 uppercase tracking-widest text-sm">Rifas Realizadas</div>
          </div>
          <div>
            <div className="text-4xl font-extrabold mb-2">98%</div>
            <div className="text-blue-100 uppercase tracking-widest text-sm">Clientes Satisfeitos</div>
          </div>
        </div>
      </section>

      {/* --- CTA FINAL --- */}
      <section className="py-24 px-4 text-center">
        <div className="max-w-3xl mx-auto bg-slate-900 rounded-3xl p-12 text-white overflow-hidden relative">
          <div className="relative z-10">
            <h2 className="text-3xl md:text-4xl font-bold mb-6">Pronto para lançar seu primeiro sorteio?</h2>
            <p className="text-slate-400 mb-10 text-lg">Junte-se a milhares de organizadores que já utilizam a RifaPro.</p>
            <a href='/register' className="bg-blue-600 text-white px-10 py-4 rounded-xl font-bold text-lg hover:bg-blue-500 transition shadow-lg">
              Criar conta gratuita
            </a>
          </div>
          {/* Decorative element */}
          <div className="absolute -bottom-10 -right-10 w-40 h-40 bg-blue-600 opacity-20 rounded-full blur-3xl"></div>
        </div>
      </section>

      <footer className="py-12 border-t border-slate-200 text-center text-slate-500 text-sm">
        <p>&copy; 2026 RifaPro SaaS. Todos os direitos reservados.</p>
      </footer>
    </div>
  );
};

export default LandingPageWelcome;